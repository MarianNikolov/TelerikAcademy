//14 Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml 
//   using the class XslTransform

using System;
using System.Xml.Xsl;

namespace TransformStyleSheet
{
    public class Startup
    {
        static void Main()
        {
            XslTransform sheetTransrormer = new XslTransform();
            sheetTransrormer.Load("../../../styleXSLT.xslt");
            sheetTransrormer.Transform("../../catalogue.xml", "../../transformedCatalogue.html");
            Console.WriteLine("Result is in folder solution.");
        }
    }
}
