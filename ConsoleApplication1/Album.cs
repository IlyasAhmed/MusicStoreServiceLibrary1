using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MusicServiceLibrary
{
    public partial class Album
    {
        public string Id;
        public string Title;
        public List<Song> Songs;
    }
}
