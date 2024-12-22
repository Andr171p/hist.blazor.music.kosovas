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
	}
}
