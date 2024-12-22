using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.models;
using System.Reflection.Emit;

namespace MusicServerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: IdentityDbContext<ApplicationUser>(options)
    {
		public virtual DbSet<Track> Tracks { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<Playlist> Playlists { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Artist>()
			.HasMany(a => a.Tracks)
			.WithOne(t => t.Artist)
			.HasForeignKey(t => t.ArtistId);

			builder.Entity<Playlist>()
			.HasMany(p => p.Tracks)
			.WithMany();

			builder.Entity<Track>()
			.Property(t => t.ReleaseDate)
			.HasDefaultValueSql("GETDATE()");

			builder.Entity<Artist>().HasData(
				new Artist { Id = 1, Name = "Metallica" },
				new Artist { Id = 2, Name = "Linkin Park" }
			);

			builder.Entity<Playlist>().HasData(
				new Playlist { Id = 1, Name = "Rock Hits" },
				new Playlist { Id = 2, Name = "Alternative Rock" }
			);

			builder.Entity<Track>().HasData(
				new Track
				{
					Id = 1,
					Title = "Enter Sandman",
					Duration = TimeSpan.FromMinutes(5),
					ArtistId = 1,
					Genre = "Heavy Metal",
					ReleaseDate = new DateTime(1991, 7, 30)
				},
				new Track
				{
					Id = 2,
					Title = "In the End",
					Duration = TimeSpan.FromMinutes(3),
					ArtistId = 2,
					Genre = "Nu Metal",
					ReleaseDate = new DateTime(2000, 10, 24)
				}
			);
		}
	}
}
