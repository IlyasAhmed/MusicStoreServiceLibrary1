using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MusicServiceLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //XDocument doc = XDocument.Load("Songs.xml");
            //var ins = doc.DescendantNodes();
            //var iosnd = doc.Descendants();
            //var authors = doc.Descendants("artist");

            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author.Value);
            //}
            //Console.ReadLine();

            string uri = @"C:\models\MusicStoreServiceLibrary\ConsoleApplication1\Songs.xml"; // your big XML file

            //foreach (var book in XmlHelper.StreamBooks(uri))
            //{
            //    Console.WriteLine("Title, Author: {0}, {1}", book.Title, book.Length);
            //}

            //StringBuilder output = new StringBuilder();

            //using (XmlReader reader = XmlReader.Create(uri))
            //{
            //    XmlWriterSettings ws = new XmlWriterSettings();
            //    ws.Indent = true;
            //    using (XmlWriter writer = XmlWriter.Create(output, ws))
            //    {

            //        // Parse the file and display each of the nodes.
            //        while (reader.Read())
            //        {
            //            switch (reader.NodeType)
            //            {
            //                case XmlNodeType.Element:
            //                    writer.WriteStartElement(reader.Name);
            //                    break;
            //                case XmlNodeType.Text:
            //                    writer.WriteString(reader.Value);
            //                    break;
            //                case XmlNodeType.XmlDeclaration:
            //                case XmlNodeType.ProcessingInstruction:
            //                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
            //                    break;
            //                case XmlNodeType.Comment:
            //                    writer.WriteComment(reader.Value);
            //                    break;
            //                case XmlNodeType.EndElement:
            //                    writer.WriteFullEndElement();
            //                    break;
            //            }
            //        }

            //    }
            //}
            //var fgdf  = output.ToString();

            XmlReader reader = XmlReader.Create(uri);
            reader.ReadToFollowing("music");
            var oin = reader.ReadInnerXml();
            //reader.MoveToFirstAttribute();
            //string title = reader.Value;

            System.Xml.Serialization.XmlSerializer reader1 =
                    new System.Xml.Serialization.XmlSerializer(typeof(Artist));
            System.IO.StreamReader file = new System.IO.StreamReader(uri);
            Artist overview = new Artist();
            overview = (Artist)reader1.Deserialize(file);

            Console.WriteLine(overview.Name);
        }
    }

}
