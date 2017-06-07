using System;
using System.IO;
using System.Linq;
using System.Reflection;
using ComputerConfigurations.Importer.Importers;
using ComputersConfigutarions.Data;

namespace ComputerConfigurations.Importer
{
    public class SampleDataImporter
    {
        private TextWriter textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Import()
        {
            // select all classes in current assembly,
            // who implementing IImporter interface

            /* var types = */
            Assembly.GetExecutingAssembly() // from current assembly
                .GetTypes() // get all .cs files (classes, interfaces ...)
                .Where(t => typeof(IImporter).IsAssignableFrom(t) // classes implementing IImporter interface
                && !t.IsInterface && !t.IsAbstract) // without interfaces and abstract classes
                .Select(t => Activator.CreateInstance(t))  // make instance for every one of the selected classes
                .OfType<IImporter>() //cast to IImporter
                .OrderBy(i => i.Order) // order of inserting tables data whit property of a class 
                .ToList()
                .ForEach(i =>
                {
                    // for each importer make db connection and TextWriter to write message anywhere
                    textWriter.WriteLine(i.Message);
                    var db = new ComputerConfigurationsSystemEntities();

                    // invoke for each importer class Get() == Action<CompanyEntities, TextWriter>
                    i.Get(db, this.textWriter);

                    textWriter.WriteLine();
                });
        }
    }
}
