using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface IPlaylistService
	{
		Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
		Task<Playlist> CreatePlaylistAsync(Playlist playlist);
		Task<bool> DeletePlaylistAsync(int id);
	}
}
