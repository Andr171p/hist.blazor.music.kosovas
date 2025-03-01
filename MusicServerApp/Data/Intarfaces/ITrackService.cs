﻿using MusicServerApp.Data.models;

namespace MusicServerApp.Data.Intarfaces
{
	public interface ITrackService
	{
		Task<IEnumerable<Track>> GetAllTracksAsync();
		Task<Track> CreateTrackAsync(Track track);
		Task<bool> DeleteTrackAsync(int id);
		Task<bool> RemoveTrackFromPlaylistAsync(int playlistId, int trackId);
		Task<bool> AddTrackToPlaylistAsync(int playlistId, Track track);
		Task<IEnumerable<Track>> GetTracksByArtistIdAsync(int artistId);
	}
}
