using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MusicServiceLibrary
{
    [DataContract]
    public class Artist
    {
        [DataMember]
        public string Name;
        [DataMember]
        public List<Album> Albums;
    }
}
