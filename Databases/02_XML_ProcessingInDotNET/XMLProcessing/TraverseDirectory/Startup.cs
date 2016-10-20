//09: Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. 
// Use tags <file> and <dir> with appropriate attributes.
// For the generation of the XML document use the class XmlWriter.
//10:  Rewrite the last exercises using XDocument, XElement and XAttribute.

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TraverseDirectory
{
    public class Startup
    {
        private const string directory = "C://AVG_Remover";

        static void Main()
        {
            StringBuilder text = new StringBuilder();

            using (XmlTextWriter xmlWriter = new XmlTextWriter("../../FileDirectories.xml", Encoding.UTF8))
            {
                xmlWriter.Formatting = Formatting.Indented;

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("dir");
                TraversFileDirectory(xmlWriter, directory, text);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }

            Console.WriteLine(text.ToString());

            XDocument xmlDocument = new XDocument(new XElement("root"));
            TraversFileDirectoryWithXDocument(xmlDocument.Root, directory);
            xmlDocument.Save("../../FileDirectoriesWithXDocument.xml");
        }

        private static void TraversFileDirectoryWithXDocument(XElement root, string path)
        {
            bool inDirectories = true;
            string[] folderDirectories = Directory.GetDirectories(path);

            if (folderDirectories.Length == 0)
            {
                folderDirectories = Directory.GetDirectories(path);
                inDirectories = false;
            }

            for (int i = 0; i < folderDirectories.Length; i++)
            {
                if (inDirectories)
                {
                    XAttribute attribute = new XAttribute("path", folderDirectories[i]);
                    XElement innerNode = new XElement("dir", attribute);
                    TraversFileDirectoryWithXDocument(innerNode, folderDirectories[i]);
                    root.Add(innerNode);
                }
                else
                {
                    XAttribute attribute = new XAttribute("fileName", Path.GetFileName(folderDirectories[i]));
                    XElement innerNode = new XElement("file", attribute);
                    root.Add(innerNode);
                }
            }
        }

        private static void TraversFileDirectory(XmlWriter writer, string path, StringBuilder text)
        {
            bool inDirectories = true;
            string[] folderDirectories = Directory.GetDirectories(path);

            if (folderDirectories.Length == 0)
            {
                folderDirectories = Directory.GetDirectories(path);
                inDirectories = false;
            }

            for (int i = 0; i < folderDirectories.Length; i++)
            {
                text.AppendLine(folderDirectories[i]);

                if (inDirectories)
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("path", folderDirectories[i]);
                    TraversFileDirectory(writer, folderDirectories[i], text);
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("fileName", Path.GetFileName(folderDirectories[i]));
                    writer.WriteEndElement();
                }
            }
        }
    }
}
