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
    public class GpuImporter : IImporter
    {
        private const int NumberOfGpus = 15;

        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return(db, tw) =>
                {
                    var gpuTypesIds = db
                    .GpuTypes
                    .Select(d => d.Id)
                    .ToList();


                    var currentgpuTyupe = gpuTypesIds[0];
                    for (int i = 0; i < NumberOfGpus; i++)
                    {
                        if (i == 9)
                        {
                            currentgpuTyupe = gpuTypesIds[1];
                        }

                        var gpu = new Gpu
                        {
                            Memory = RandomGenerator.GetRandomString(5, 40),
                            Model = RandomGenerator.GetRandomString(5, 40),
                            Vendor = RandomGenerator.GetRandomString(5, 40),
                            TypeId = currentgpuTyupe
                        };

                        db.Gpus.Add(gpu);
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing GPUs ***";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }
    }
}
