using System.Collections.Generic;

namespace backgroundworker
{
    public class Afspeellijst : IPlaylist, ISongCollection
    {
        List<Song> Songs { get; set; } = new List<Song>();
        public string Name { get; }
        public int PlaylistID { get; }
        public Afspeellijst(string name) => Name = name;

        public Afspeellijst(List<Song> songs, string name)
        {
            Name = name;
            Songs = songs;
        }
        public Afspeellijst(string name, int playlistID)
        {
            Name = name;
            PlaylistID = playlistID;
        }
        public Song[] GetAllSongs() => Songs.ToArray();
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
