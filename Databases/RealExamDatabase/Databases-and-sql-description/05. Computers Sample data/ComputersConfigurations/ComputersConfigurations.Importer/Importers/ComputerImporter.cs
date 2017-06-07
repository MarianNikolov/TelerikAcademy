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
    public class ComputerImporter : IImporter
    {
        private const int NumberOfComputers = 60;

        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var computerTypesIds = db
                    .CompyterTypes
                    .Select(d => d.Id)
                    .ToList();

                    var cpuTypesIds = db
                    .Cpus
                    .Select(d => d.Id)
                    .ToList();

                    var allGpus = db
                    .Gpus
                    .ToList();

                    var allStoragDevices = db
                    .StorageDevices
                    .ToList();

                    var currentTypeIndex = 0;
                    var currentType = computerTypesIds[currentTypeIndex];

                    for (int i = 0; i < NumberOfComputers; i++)
                    {
                        if (i % 20 == 0)
                        {
                            if (currentTypeIndex + 1 < computerTypesIds.Count)
                            {
                                currentTypeIndex++;
                                currentType = computerTypesIds[currentTypeIndex];
                            }
                        }

                        var currentCpuId = RandomGenerator.GetRandomNumber(0, cpuTypesIds.Count -1);

                        var Computer = new Computer
                        {
                            Vendor = RandomGenerator.GetRandomString(5, 40),
                            Model = RandomGenerator.GetRandomString(5, 40),
                            ComputerTypeId = currentType,
                            CpuId = cpuTypesIds[currentCpuId],
                        };

                        var currentFirstGpuIndex = RandomGenerator.GetRandomNumber(0, allGpus.Count - 1);
                        var currentSecondGpuIndex = RandomGenerator.GetRandomNumber(0, allGpus.Count - 1);

                        Computer.Gpus.Add(allGpus[currentFirstGpuIndex]);
                        Computer.Gpus.Add(allGpus[currentSecondGpuIndex]);

                        var currentFirstStorageDeviceIndex = RandomGenerator.GetRandomNumber(0, allGpus.Count - 1);
                        var currentSecondStorageDeviceIndex = RandomGenerator.GetRandomNumber(0, allGpus.Count - 1);

                        Computer.StorageDevices.Add(allStoragDevices[currentFirstStorageDeviceIndex]);
                        Computer.StorageDevices.Add(allStoragDevices[currentSecondStorageDeviceIndex]);

                        db.Computers.Add(Computer);
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing Computers ***";
            }
        }

        public int Order
        {
            get
            {
                return 7;
            }
        }
    }
}
