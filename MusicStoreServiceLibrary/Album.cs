using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MusicServiceLibrary
{
    [DataContract]
    public class Album
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Title;
        [DataMember]
        public List<Song> Songs;
    }
}
