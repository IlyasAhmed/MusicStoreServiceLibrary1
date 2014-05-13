using System.Collections.Generic;
using System.ServiceModel;

namespace MusicServiceLibrary
{
    [ServiceContract]
    interface IMusicService
    {
        [OperationContract]
        List<Artist> GetAllArtists();

        [OperationContract]
        Artist GetArtistByName(string artistName);

        [OperationContract]
        Album GetAlbumByID(string artistName, string albumId);

        [OperationContract]
        List<Song> GetSongsByAlbum(string artistName, string albumTitle);

        [OperationContract]
        void AddSong(string artistName, string albumTitle, string songTitle, string songLength);

        [OperationContract]
        List<Album> GetAlbumns(string artistName);

        [OperationContract]
        void UpdateSongInfo(string artistName, string albumTitle, string songID, string songTitle, string songLength);

    }
}
