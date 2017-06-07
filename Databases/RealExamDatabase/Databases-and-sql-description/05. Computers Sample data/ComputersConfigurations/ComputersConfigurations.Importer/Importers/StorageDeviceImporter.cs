using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerConfigurations.Importer;
using ComputerConfigurations.Importer.Importers;
using ComputersConfigutarions.Data;

namespace ComputersConfigurations.Importer.Importers
{
    public class StorageDeviceImporter : IImporter
    {
        private const int NumberOfStorageDevice = 40;

        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
            {
                var storageDeviceTypesIds = db
                .StorageDeviceTypes
                .Select(d => d.Id)
                .ToList();

                var currentType = storageDeviceTypesIds[0];
                for (int i = 0; i < NumberOfStorageDevice; i++)
                {
                    if (i % 30 == 10)
                    {
                        currentType = storageDeviceTypesIds[1];
                    }

                    var storageDevice = new StorageDevice
                    {
                        Vendor = RandomGenerator.GetRandomString(5, 40),
                        Model = RandomGenerator.GetRandomString(5, 40),
                        Size = RandomGenerator.GetRandomString(5, 40),
                        TypeId = currentType
                    };

                    db.StorageDevices.Add(storageDevice);
                }

                db.SaveChanges();
            };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing Storage device ***";
            }
        }

        public int Order
        {
            get
            {
                return 6;
            }
        }
    }
}
