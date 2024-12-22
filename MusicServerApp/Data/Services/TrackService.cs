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
	}
}
