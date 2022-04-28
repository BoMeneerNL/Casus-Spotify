using System.Collections.Generic;

namespace backgroundworker
{
    public class Speellijst : IPlaylist, ISongCollection
    {
        List<Song> Songs { get; set; } = new List<Song>();
        public Speellijst()
        {

        }
        public Song[] GetAllSongs()
        {
            return Songs.ToArray();
        }
        public string[] GetAllSongNames()
        {
            string[] songnames = new string[Songs.Count];
            for (int i = 0; i < Songs.Count; i++)
                songnames[i] = Songs[i].Name;
            return songnames;
        }
        public void AddSong(Song song) => Songs.Add(song);
        public void RemoveSong(Song song) => Songs.Remove(song);
        public void RemoveSong(int index) => Songs.RemoveAt(index);
    }
}
