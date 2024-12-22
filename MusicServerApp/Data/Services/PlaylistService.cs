using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Services
{
	public class PlaylistService
	{
		private readonly ApplicationDbContext _context;

		public PlaylistService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
		{
			return await _context.Playlists.ToListAsync();
		}

		public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
		{
			_context.Playlists.Add(playlist);
			await _context.SaveChangesAsync();
			return playlist;
		}

		public async Task<bool> DeletePlaylistAsync(int id)
		{
			var playlist = await _context.Playlists.FindAsync(id);
			if (playlist == null)
				return false;

			_context.Playlists.Remove(playlist);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
