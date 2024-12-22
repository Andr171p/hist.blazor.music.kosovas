using System.ComponentModel.DataAnnotations;

namespace MusicServerApp.Data.models
{
	public class Artist
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Track> Tracks { get; set; } = new List<Track>();
	}
}
