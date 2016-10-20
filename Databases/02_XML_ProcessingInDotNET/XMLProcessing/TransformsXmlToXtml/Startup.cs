//13 Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, 
// formatted for viewing in a standard Web-browser.

using System;
using System.Xml.Xsl;

namespace TransformsXmlToXtml
{
    public class Startup
    {
        static void Main()
        {
            XslCompiledTransform transformator = new XslCompiledTransform();
            transformator.Load("../../../styleXSLT.xslt");
            transformator.Transform("../../catalogue.xml", "../../catalogue.html");
            Console.WriteLine("HTML is ready... find catalogue.html in solution folder");
        }
    }
}
