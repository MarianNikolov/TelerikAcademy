using System;
using ComputerConfigurations.Importer;

namespace ComputersConfigurations.Importer
{
    public class Startup
    {
        static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
