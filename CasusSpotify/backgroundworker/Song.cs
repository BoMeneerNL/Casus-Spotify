namespace backgroundworker
{
    public class Song
    {
        public string Name { get; set; }
        private string Artiest { get; set; }
        public int Duration { get; set; }
        public string Album { get; set; }
        public Song(string name = "", string artiest = "", int duration = 0, string album = "NO ALBUM")
        {
            Name = name;
            Artiest = artiest;
            Duration = duration;
            Album = album;
        }
        public override string ToString() => $"{Name} - {Artiest} - {calculate_duration(Duration) } - {Album}";
        public string calculate_duration(int duration)
        {
            int minutes = duration / 60;
            int seconds = duration % 60;
            return $"{minutes}:{seconds}";
        }
    }
}
