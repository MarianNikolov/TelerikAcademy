// 11 Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
// Rewrite the previous using LINQ query.

using System;
using System.Linq;
using System.Xml.Linq;

namespace FiveYearsAgoLINQ
{
    public class Startup
    {
        internal static void Main()
        {
            int currentYear = DateTime.Now.Year;
            int yearsLongAgo = 5;

            XDocument xmlCatalogue = XDocument.Load("../../catalogue.xml");
            var albums =
                from album in xmlCatalogue.Descendants("album")
                where currentYear > int.Parse(album.Element("year").Value) + yearsLongAgo
                select new XElement("album",
                    new XElement("name", album.Element("name").Value),
                    new XElement("price", album.Element("price").Value),
                    new XElement("year", album.Element("year").Value));

            XDocument fiveYearsAgoAlbums = new XDocument(new XElement("albums", albums));
            fiveYearsAgoAlbums.Save("../../oldAlbumsLinq.xml");
            Console.WriteLine("See result in oldAlbumsLinq.xml");
        }
    }
}
