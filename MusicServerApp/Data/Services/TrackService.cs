using Microsoft.EntityFrameworkCore;
using MusicServerApp.Data.Intarfaces;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Services
{
	public class TrackService : ITrackService
	{
		private readonly ApplicationDbContext _context;

		public TrackService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Track>> GetAllTracksAsync()
		{
			return await _context.Tracks.ToListAsync();
		}

		public async Task<Track> CreateTrackAsync(Track track)
		{
			_context.Tracks.Add(track);
			await _context.SaveChangesAsync();
			return track;
		}

		public async Task<bool> DeleteTrackAsync(int id)
		{
			var track = await _context.Tracks.FindAsync(id);
			if (track == null)
				return false;

			_context.Tracks.Remove(track);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> RemoveTrackFromPlaylistAsync(int playlistId, int trackId)
		{
			var playlist = await _context.Playlists.Include(p => p.Tracks).FirstOrDefaultAsync(p => p.Id == playlistId);

			if (playlist == null)
			{
				return false;
			}

			var trackToRemove = playlist.Tracks.FirstOrDefault(t => t.Id == trackId);

			if (trackToRemove != null)
			{
				playlist.Tracks.Remove(trackToRemove);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<bool> AddTrackToPlaylistAsync(int playlistId, Track track)
		{
			var playlist = await _context.Playlists.Include(p => p.Tracks).FirstOrDefaultAsync(p => p.Id == playlistId);

			if (playlist == null)
			{
				return false;
			}

			if (!playlist.Tracks.Any(t => t.Id == track.Id))
			{
				playlist.Tracks.Add(track);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<IEnumerable<Track>> GetTracksByArtistIdAsync(int artistId)
		{
			return await _context.Tracks.Where(t => t.ArtistId == artistId).ToListAsync();
		}
	}
}
