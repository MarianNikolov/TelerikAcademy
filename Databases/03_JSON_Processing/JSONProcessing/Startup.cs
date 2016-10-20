//Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:

//    01 The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw

//    02 Download the content of the feed programatically
//        You can use WebClient.DownloadFile()
//    03 Parse the XML from the feed to JSON
//    04 Using LINQ-to-JSON select all video titles and print them on the console
//    05 Parse the videos' JSON to POCO
//    06 Using the POCOs create a HTML page that shows all videos from the RSS
//        Use<iframe>
//        Provide links, that navigate to their videos in YouTube

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONProcessing
{
    public class Startup
    {
        static void Main()
        {
            string pathToFile = "../../RSSNews.xml";
            WebClient client = new WebClient();
            client.DownloadFile("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw", pathToFile);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathToFile);

            string result = JsonConvert.SerializeObject(xmlDocument, Newtonsoft.Json.Formatting.Indented);

            JObject json = JObject.Parse(result);

            PrintOnConsoleVideosTitleWithLINQToJSON(json);
            HTMLBuilder(json);
        }

        private static void HTMLBuilder(JObject json)
        {
            IList<Entry> entries = new List<Entry>();

            foreach (JObject item in json["feed"]["entry"])
            {
                entries.Add(JsonConvert.DeserializeObject<Entry>(item.ToString()));
            }

            XmlWriterSettings settingsWriter = new XmlWriterSettings();
            settingsWriter.Indent = true;
            settingsWriter.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlTextWriter.Create("../../verySlowLoadingRSS.html", settingsWriter))
            {
                writer.WriteDocType("HTML5", null, null, null);

                writer.WriteStartElement("html");
                writer.WriteStartElement("body");
                writer.WriteStartElement("style");
                writer.WriteAttributeString("type", "text/css");
                writer.WriteValue(@"
                      body {
                      	font: Arial;
                      	}
                      	
                      iframe {
                          witdh: 250px;
                          height: 175px; 
                      }
                      
                      .container {
                          display: inline-block;
                          margin: 10px;
                          width: 300px;
                          height: 250px;
                          overflow: auto;
                      }
                      
                      .container h3 {
                          text-align:center;
                          font-size: 15px;
                      }
                      
                      .container h3 a {
                          text-decoration: none;
                      }
                      
                      .container h3 a:hover {
                          text-decoration: underline;
                      }
                      ");

                writer.WriteEndElement();
                writer.WriteStartElement("title");
                writer.WriteValue("RSS Youtube Channel - Telrik Academy");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("body");
                writer.WriteStartElement("main");

                foreach (Entry entry in entries)
                {
                    writer.WriteStartElement("div");
                    writer.WriteAttributeString("class", "container");

                    writer.WriteStartElement("iframe");
                    writer.WriteAttributeString("src", entry.VideoLink.Href);
                    writer.WriteAttributeString("frameborder", "0");
                    writer.WriteAttributeString("allowfullscreen", "allowfullscreen");
                    writer.WriteValue(string.Empty);
                    writer.WriteEndElement();

                    writer.WriteStartElement("h3");
                    writer.WriteStartElement("a");
                    writer.WriteAttributeString("href", entry.VideoLink.Href);
                    writer.WriteValue(entry.Title);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private static void PrintOnConsoleVideosTitleWithLINQToJSON(JObject json)
        {
            int index = 1;
            IEnumerable<string> titles = json["feed"]["entry"]
                .Select(entry => $"Title #{index++}: {entry["title"]}");

            Console.OutputEncoding = Encoding.Unicode;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
