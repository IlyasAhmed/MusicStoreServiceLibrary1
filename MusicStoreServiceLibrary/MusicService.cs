using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MusicServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MusicService : IMusicService
    {

        List<Artist> artists = new List<Artist>();

        

        public List<Artist> GetAllArtists()
        {
            //XDocument db = GetDb();
            //List<Artist> lstBooks
            //     =
            //    (from book in db.Descendants("artist")
            //     select new Artist()
            //     {
            //         Name = book.Attribute("name").Value
            //     }).ToList<Artist>();

            //return lstBooks;
            return artists;
        }

        public Artist GetArtistByName(string artistName)
        {
            return artists.FirstOrDefault(artist => artist.Name == artistName);
        }


        public Album GetAlbumByID(string artistName, string albumId)
        {
            return GetAllAblums(artistName).ToList().Find(al => al.Id == albumId);
        }

        public List<Song> GetSongsByAlbum(string artistName, string albumTitle)
        {
            return
                artists.Find(a => a.Name == artistName)
                       .Albums.Find(al => al.Title == albumTitle)
                       .Songs;
        }

        //public void UpdateSongInfo(string artistName, string albumTitle, Song songToUpdate)
        //{
        //    int songId;

        //    var artist = GetArtistByName(artistName);
        //    foreach (
        //        var song in
        //            artist.Albums.Where(album => album.Title == albumTitle)
        //                  .SelectMany(album => album.Songs.Where(song => song.Title == songToUpdate.Title)))
        //    {
        //        songId = song.SongId;
        //    }

        //    var songId = albums.Find(album => album.Title == albumTitle).Songs.Find(song => song.Title == songToUpdate.Title).SongId);
        //    albums.Find(album => album.Title == albumTitle).Songs.Remove(songToUpdate);
        //}


        public void AddSong(string artistName, string albumTitle, string songTitle, string songLength)
        {
            var songToAdd = new Song();

            songToAdd.SongId = GetNextSongID(artistName, albumTitle).ToString();
            songToAdd.Title = songTitle;
            songToAdd.Length = songLength;

            artists.Find(a => a.Name == artistName)
                          .Albums.Find(al => al.Title == albumTitle).Songs.Add(songToAdd);
        }

        //public void UpdateSong(string albumTitle, Song song)
        //{
        //    song.SongId = GetNextSongID(albumTitle);
        //    albums.Find(album => album.Title == albumTitle).Songs.Find(s => s.SongId == song.SongId);
        //}

        public List<Album> GetAlbumns(string artistName)
        {
            return artists.Find(a => a.Name == artistName)
                          .Albums;
        }


        //public void AddSong(string albumTitle, string songTitle, string songLength, string songId)
        //{

        //    XElement songNode = new XElement("song");
        //    songNode.Add(new XAttribute("title", songTitle));
        //    songNode.Add(new XElement("length", songLength));
        //    songNode.Add(new XElement("SongId", songId));
        //    XElement albumToAdd = (from album in _repo.Descendants("album")
        //               where album.Attribute("title").Value.Equals(albumTitle)
        //               select album).ToList().FirstOrDefault();

        //    if (albumToAdd != null) 
        //        albumToAdd.Add(songNode);
        //}

        public void UpdateSongInfo(string artistName, string albumTitle, string songID, string songTitle, string songLength)
        {
            var songToUpdate = new Song();
            songToUpdate.SongId = songID;
            songToUpdate.Title = songTitle;
            songToUpdate.Length = songLength;

            var songToRemove = GetAllSongs(artistName, albumTitle).Find(s => s.SongId == songID);
            artists.Find(a => a.Name == artistName)
                   .Albums.Find(al => al.Title == albumTitle)
                   .Songs.Remove(songToRemove);

            artists.Find(a => a.Name == artistName)
                  .Albums.Find(al => al.Title == albumTitle)
                  .Songs.Add(songToUpdate);

        }

        private List<Song> GetAllSongs(string artistName, string albumTitle)
        {
            return GetAllAblums(artistName).Find(al => al.Title == albumTitle).Songs;
        }

        private List<Song> GetAllSongs(string artistName, int albumId)
        {
            return GetAllAblums(artistName).Find(al => al.Id == albumId.ToString()).Songs;
        }

        private List<Album> GetAllAblums(string artistName)
        {
            return artists.Find(a => a.Name == artistName).Albums;
        }

        private int GetNextAlbumID(string artistName)
        {
            return int.Parse(GetAllAblums(artistName).Max(al => al.Id)) + 1;
        }

        private int GetNextSongID(string artistName, string albumTitle)
        {
            return
                int.Parse(artists.Find(a => a.Name == artistName)
                       .Albums.Find(al => al.Title == albumTitle)
                       .Songs.Max(s => s.SongId)) + 1;
        }

        private void SerializeFile()
        {
            const string songsXMLfile = "Songs.xml";

            var serializer = new XmlSerializer(typeof(Artist));
            var file = new StreamWriter(Path.GetFullPath(songsXMLfile));
            serializer.Serialize(file, artists);
            file.Close();
        }

        private void DeserializeFile()
        {
            const string songsXMLfile = "Songs.xml";

            var serializer = new XmlSerializer(typeof(Artist));
            TextReader file = new StreamReader(songsXMLfile);
            var a = (Artist)serializer.Deserialize(file);
            file.Close();
        }

        private XDocument GetDb()
        {
            return XDocument.Load("Songs.xml");
        }
    }
}
