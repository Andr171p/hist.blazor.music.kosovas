namespace MusicServerApp.Data.models
{
	public class Track
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		public Artist Artist { get; set; }
		public string Genre { get; set; }
		public DateTime RealeseDate { get; set; }
	}
}
