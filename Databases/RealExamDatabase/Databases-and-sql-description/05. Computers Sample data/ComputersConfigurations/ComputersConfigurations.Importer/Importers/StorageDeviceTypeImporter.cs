using System;
using System.IO;
using ComputersConfigutarions.Data;

namespace ComputerConfigurations.Importer.Importers
{
    public class StorageDeviceTypeImporter : IImporter
    {
        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var typeSSD = new StorageDeviceType { Name = "SSD" };
                    var typeHDD = new StorageDeviceType { Name = "HDD" };

                    db.StorageDeviceTypes.Add(typeSSD);
                    db.StorageDeviceTypes.Add(typeHDD);

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing storage device types ***";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }
    }
}
