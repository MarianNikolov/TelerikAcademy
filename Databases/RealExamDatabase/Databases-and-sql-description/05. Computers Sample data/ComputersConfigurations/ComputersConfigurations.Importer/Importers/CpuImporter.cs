using System;
using System.IO;
using System.Linq;
using ComputerConfigurations.Importer;
using ComputerConfigurations.Importer.Importers;
using ComputersConfigutarions.Data;

namespace ComputersConfigurations.Importer.Importers
{
    public class CpuImporter : IImporter
    {
        private const int NumberOfCpus = 10;

        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    for (int i = 0; i < NumberOfCpus; i++)
                    {
                        var cpu = new Cpu
                        {
                            Vendor = RandomGenerator.GetRandomString(5, 40),
                            Model = RandomGenerator.GetRandomString(5, 40),
                            NumberOfCorse = RandomGenerator.GetRandomNumber(1, 64),
                            ClockCycles = RandomGenerator.GetRandomString(5, 40)
                        };

                        db.Cpus.Add(cpu);
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing CPUs ***";
            }
        }

        public int Order
        {
            get
            {
                return 5;
            }
        }
    }
}
