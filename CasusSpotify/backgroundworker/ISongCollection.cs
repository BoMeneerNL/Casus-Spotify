namespace backgroundworker
{
    internal interface ISongCollection
    {
        Song[] GetAllSongs();
        string[] GetAllSongNames();
    }
}
