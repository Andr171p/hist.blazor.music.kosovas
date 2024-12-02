using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface ITrackDataService
	{
		Task<IEnumerable<Track>> GetAllTracksAsync();
		Task AddTrackAsync(Track track);
		Task UpdateTrackAsync(Track tarck);	
		Task DeleteTrackAsync(int id);
		Task<ICollection<Track>> GetTrackAsync(string query);
	}
}
