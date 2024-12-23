using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.Intarfaces;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Services
{
	public class ArtistService : IArtistService
	{
		private readonly ApplicationDbContext _context;

		public ArtistService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
		{
			return await _context.Artists.ToListAsync();
		}

		public async Task<Artist?> GetArtistByIdAsync(int id)
		{
			return await _context.Artists.FirstAsync(x => x.Id == id);
		}

		public async Task<Artist> CreateArtistAsync(Artist artist)
		{
			_context.Artists.Add(artist);
			await _context.SaveChangesAsync();
			return artist;
		}

		public async Task<bool> DeleteArtistAsync(int id)
		{
			var artist = await _context.Artists.FindAsync(id);
			if (artist == null)
				return false;

			_context.Artists.Remove(artist);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Artist>> GetAllArtistsWithTracksAsync()
		{
			return await _context.Artists.Include(a => a.Tracks).ToListAsync();
		}

		public async Task<Artist?> GetArtistWithTracksByIdAsync(int id)
		{
			return await _context.Artists
				.Where(a => a.Id == id)
				.Include(a => a.Tracks)
				.FirstOrDefaultAsync();
		}
	}
}
