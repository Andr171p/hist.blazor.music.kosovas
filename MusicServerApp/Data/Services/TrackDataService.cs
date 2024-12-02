using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MusicServerApp.Data.Intarfaces;
using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Services
{
	public class TrackDataService(ApplicationDbContext context) : ITrackDataService
	{
		public async Task<IEnumerable<Track>> GetAllTracksAsync()
		{
			return await context.Tracks.ToListAsync();
		}

		public async Task AddTrackAsync(Track track)
		{
			if (track.Id == 0)
			{
				await context.Tracks.AddAsync(track);
			}
			else
			{
				context.Tracks.Update(track);
			}
			await context.SaveChangesAsync();
		}

		public async Task UpdateTrackAsync(Track track)
		{
			context.Tracks.Update(track);
			await context.SaveChangesAsync();
		}

		public async Task DeleteTrackAsync(int id)
		{
			var track = await context.Tracks.FirstAsync(x => x.Id == id);
			if (track != null)
			{
				context.Tracks.Remove(track);
				await context.SaveChangesAsync();
			}
		}

		public async Task<ICollection<Track>> GetTrackAsync(string query)
		{
			return await context.Tracks.Where(c => c.Title.Contains(query)).ToListAsync();
		}
	}
}
