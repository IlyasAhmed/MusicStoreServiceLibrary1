using System.Runtime.Serialization;

namespace MusicServiceLibrary
{
    [DataContract]
    public class Song
    {
        [DataMember]
        public string SongId;
        [DataMember]
        public string Title;
        [DataMember]
        public string Length;
    }
}
