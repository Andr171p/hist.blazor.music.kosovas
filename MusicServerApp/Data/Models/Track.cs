namespace MusicServerApp.Data.models
{
	public class Track
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public TimeSpan Duration { get; set; }
		public int ArtistId {  get; set; }
		public Artist Artist { get; set; } = null!;
		public string Genre { get; set; } = null!;
		public DateTime ReleaseDate { get; set; }
	}
}
