﻿//01 Create a XML file representing catalogue.
    // The catalogue should contain albums of different artists.
    // For each album you should define: name, artist, year, producer, price and a list of songs.
    // Each song should be described by title and duration.
//02 Write program that extracts all different artists which are found in the catalog.xml.
    // For each author you should print the number of albums in the catalogue.
    // Use the DOM parser and a hash-table.
//03 Implement the previous using XPath.
//04 Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
//05 Write a program, which using XmlReader extracts all song titles from catalog.xml.
//06 Rewrite the same using XDocument and LINQ query.
//07 In a text file we are given the name, address and phone number of given person(each at a single line).
    // Write a program, which creates new XML document, which contains these data in structured XML format.
//08 Write a program, which(using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, in which stores in appropriate way the names of all albums and their authors.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XMLProcessing
{
    public class Startup
    {
        static void Main()
        {
            // please copy catalogue.xml in below directory, 
            // or change below url string to directory where you unzip homework :)
            var url = @"C:\data\catalogue.xml";

            // methods for every task
            WriteOnConsoleXMLWithXmlDocumentClass(url);
            // WriteOnConsoleAuthorsAndNumberOfTheirAlbums(url);
            // WriteOnConsoleAuthorsAndNumberOfTheirAlbumsWithXPath(url);
            // DeleteAlbumsWithPriceGreaterThan20WithDOMParser(url);
            // WriteOnConsoleAllSongsWithXmlReader(url);
            // WriteOnConsoleAllSongsWithXDicumentAndLINQ(url);
            // CreateNewXmlFileWithPersonInfo();
            // ReadFileCatalogueAndCreatNewXMLFileWithAuthorsNamesAndTheirAlbumsNames(url);
        }

        private static void ReadFileCatalogueAndCreatNewXMLFileWithAuthorsNamesAndTheirAlbumsNames(string url)
        {
            XElement albums = new XElement("albums");

            using (var reader = XmlReader.Create(url))
            {
                string authorName = string.Empty;
                string albumName = string.Empty;

                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        albumName = reader.ReadInnerXml();
                    }

                    if (reader.Name == "artist")
                    {
                        authorName = reader.ReadInnerXml();
                    }

                    if (!string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(albumName))
                    {
                        XElement currentAuthorWithAlbum = CreateAlbum(authorName, albumName);
                        albums.Add(currentAuthorWithAlbum);
                        authorName = string.Empty;
                        albumName = string.Empty;
                    }
                }
            };

            albums.Save("../../album.xml");
        }

        private static XElement CreateAlbum(string authorName, string albumName)
        {
            XElement album =
                new XElement("album",
                new XElement("authorName", authorName),
                new XElement("albumName", albumName));

            return album;
        }

        private static void CreateNewXmlFileWithPersonInfo()
        {
            XElement person =
                new XElement("person", 
                new XAttribute("id", "1"),
                    new XElement("name", "Pesho"),
                    new XElement("address", "Sofia"),
                    new XElement("phoneNumber", "0888 43 32 43"));

            person.Save("../../person.xml");

            Console.WriteLine("Successfully created file person.xml!");
            Console.WriteLine();
            Console.WriteLine("With content:");
            Console.WriteLine(person);
        }

        private static void WriteOnConsoleAllSongsWithXDicumentAndLINQ(string url)
        {
            XDocument doc = XDocument.Load(url);

            IEnumerable<XElement> songs = doc.Root.Elements("album")
                .Select(albums => albums.Element("songs"));

            IEnumerable<string> titles = songs
                .SelectMany(title => title.Elements("song")
                .Select(s => s.Element("title").Value));

            titles.ToList().ForEach(t => Console.WriteLine(t));
        }

        private static void WriteOnConsoleAllSongsWithXmlReader(string url)
        {
            using (var reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            };
        }

        private static void DeleteAlbumsWithPriceGreaterThan20WithDOMParser(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlElement catalogue = doc.DocumentElement;

            foreach (XmlElement album in catalogue)
            {
                var currentPrice = album["price"].InnerText;
                if (int.Parse(currentPrice) > 20)
                {
                    catalogue.RemoveChild(album["price"].ParentNode);
                    doc.Save(url);
                    Console.WriteLine("Successfully cleared album 'Rosenrot' with price 22!");
                }
            }
        }

        private static void WriteOnConsoleAuthorsAndNumberOfTheirAlbumsWithXPath(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            string xPath = "/catalogue/album/artist";

            var artist = doc.SelectNodes(xPath);

            Dictionary<string, int> authorsAndNumberOfAlbums = new Dictionary<string, int>();

            foreach (XmlElement name in artist)
            {
                var currentAuthor = name.InnerText;
                if (authorsAndNumberOfAlbums.ContainsKey(currentAuthor))
                {
                    authorsAndNumberOfAlbums[currentAuthor]++;
                }
                else
                {
                    authorsAndNumberOfAlbums.Add(currentAuthor, 1);
                }
            }

            foreach (var author in authorsAndNumberOfAlbums)
            {
                Console.WriteLine($"Artist: {author.Key}");
                Console.WriteLine($"Number of albums: {author.Value}");
                Console.WriteLine();
            }

            Console.WriteLine("======================================");
            Console.WriteLine();
        }

        private static void WriteOnConsoleAuthorsAndNumberOfTheirAlbums(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement catalogue = doc.DocumentElement;

            Dictionary<string, int> authorsAndNumberOfAlbums = new Dictionary<string, int>();

            foreach (XmlElement album in catalogue)
            {
                var currentAuthor = album["artist"].InnerText;
                if (authorsAndNumberOfAlbums.ContainsKey(currentAuthor))
                {
                    authorsAndNumberOfAlbums[currentAuthor]++;
                }
                else
                {
                    authorsAndNumberOfAlbums.Add(album["artist"].InnerText, 1);
                }
            }

            foreach (var artist in authorsAndNumberOfAlbums)
            {
                Console.WriteLine($"Artist: {artist.Key}");
                Console.WriteLine($"Number of albums: {artist.Value}");
                Console.WriteLine();
            }

            Console.WriteLine("======================================");
            Console.WriteLine();
        }

        private static void WriteOnConsoleXMLWithXmlDocumentClass(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlElement catalogue = doc.DocumentElement;
            foreach (XmlElement album in catalogue)
            {
                Console.WriteLine($"Album: {album["name"].InnerText}");
                Console.WriteLine($" Artist: {album["artist"].InnerText}");
                Console.WriteLine($" Year: {album["year"].InnerText}");
                Console.WriteLine($" Price: {album["price"].InnerText}");
                Console.WriteLine("  Songs: ");

                XmlElement songsInAlbum = album["songs"];
                foreach (XmlElement song in songsInAlbum)
                {
                    Console.WriteLine($"   Song: {song["title"].InnerText}");
                    Console.WriteLine($"   Duration: {song["buration"].InnerText}");
                }

                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine();
            }
        }
    }
}
