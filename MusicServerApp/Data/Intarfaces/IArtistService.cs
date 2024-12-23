using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface IArtistService
	{
		Task<IEnumerable<Artist>> GetAllArtistsAsync();
		Task<Artist?> GetArtistByIdAsync(int id);
		Task<Artist> CreateArtistAsync(Artist artist);
		Task<bool> DeleteArtistAsync(int id);
		Task<IEnumerable<Artist>> GetAllArtistsWithTracksAsync();
		Task<Artist?> GetArtistWithTracksByIdAsync(int id);
	}
}
