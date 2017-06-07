using System;
using System.IO;
using ComputersConfigutarions.Data;

namespace ComputerConfigurations.Importer.Importers
{
    public class GpuTypesImporter : IImporter
    {
        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var typeInternal = new GpuType { Name = "internal" };
                    var typeExternal = new GpuType { Name = "external" };

                    db.GpuTypes.Add(typeInternal);
                    db.GpuTypes.Add(typeExternal);

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing GPU types ***";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }
    }
}
