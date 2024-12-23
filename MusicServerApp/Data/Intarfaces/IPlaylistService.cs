using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface IPlaylistService
	{
		Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
		Task<Playlist?> GetByIdAsync(int id);
		Task<Playlist> CreatePlaylistAsync(Playlist playlist);
		Task<bool> DeletePlaylistAsync(int id);
		Task AddTrackToPlaylistAsync(int playlistId, Track track);
		Task<Playlist?> GetPlaylistWithTracksByIdAsync(int id);
	}
}
