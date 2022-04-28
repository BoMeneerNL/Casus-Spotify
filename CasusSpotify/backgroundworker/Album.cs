using System.Collections.Generic;

namespace backgroundworker
{
    internal class Album : ISongCollection
    {
        List<Song> Songs { get; set; } = new List<Song>();
        int AlbumID { get; set; }
        public int Nummers { get; set; }
        public Song[] GetAllSongs() => Songs.ToArray();
        public string[] GetAllSongNames()
        {
            string[] songnames = new string[Songs.Count];
            for (int i = 0; i < Songs.Count; i++)
                songnames[i] = Songs[i].Name;
            return songnames;
        }
    }
}
