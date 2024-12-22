using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface IArtistService
	{
		Task<IEnumerable<Artist>> GetAllArtistsAsync();
		Task<Artist> CreateArtistAsync(Artist artist);
		Task<bool> DeleteArtistAsync(int id);
	}
}
