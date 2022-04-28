namespace backgroundworker

{
    public class Song
    {
        public string Name { get; set; }
        private string Artiest { get; set; }
        public int Duration { get; set; }

        public Song(string name = "", string artiest = "",int duration = 0)
        {
            Name = name;
            Artiest = artiest;
            Duration = duration;
        }
        public override string ToString()
        {
            return $"{Name} - {Artiest} - {calculate_duration(Duration)}";
        }
        public string calculate_duration(int duration)
        {
            int minutes = duration / 60;
            int seconds = duration % 60;
            return $"{minutes}:{seconds}";
        }
    }
}
