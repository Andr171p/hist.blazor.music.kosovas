using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.Intarfaces;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Services
{
	public class PlaylistService : IPlaylistService
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

		public async Task<Playlist?> GetByIdAsync(int id)
		{
			return await _context.Playlists.FirstAsync(x => x.Id == id);
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

		public async Task AddTrackToPlaylistAsync(int playlistId, Track track)
		{
			var playlist = await _context.Playlists.FindAsync(playlistId);

			if (playlist == null)
			{
				throw new ArgumentException($"Плейлист с Id {playlistId} не найден.", nameof(playlistId));
			}

			playlist.Tracks.Add(track);
			await _context.SaveChangesAsync();
		}

		public async Task<Playlist?> GetPlaylistWithTracksByIdAsync(int id)
		{
			return await _context.Playlists
				.Include(p => p.Tracks)
				.FirstOrDefaultAsync(p => p.Id == id);
		}
	}
}
