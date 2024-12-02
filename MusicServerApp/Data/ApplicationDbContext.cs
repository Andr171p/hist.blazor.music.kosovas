using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
		public virtual DbSet<Track> Tracks { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<Playlist> Playlists { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Track>().ToTable("Tracks");
			builder.Entity<Artist>().ToTable("Artists");
			builder.Entity<Playlist>().ToTable("Playlists");
		}
	}
}
