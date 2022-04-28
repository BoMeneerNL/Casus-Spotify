namespace backgroundworker
{
    public interface IPlaylist
    {
        void AddSong(Song song);
        void RemoveSong(Song song);
        void RemoveSong(int index);
    }
}
