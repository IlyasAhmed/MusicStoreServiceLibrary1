using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MusicServiceLibrary;

namespace ConsoleApplication1
{
    public static class XmlHelper
    {
        public static IEnumerable<Song> StreamBooks(string uri)
        {
            using (XmlReader reader = XmlReader.Create(uri))
            {
                string title = null;
                string length = null;

                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "song")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "title")
                            {
                                title = reader.ReadString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "length")
                            {
                                length = reader.ReadString();
                                break;
                            }
                        }
                        yield return new Song() {Title = title, Length = length};
                    }
                }
            }
        }
    }
}
