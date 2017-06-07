using System;
using System.IO;
using ComputersConfigutarions.Data;

namespace ComputerConfigurations.Importer.Importers
{
    public class ComputersTypesImporter : IImporter
    {
        public Action<ComputerConfigurationsSystemEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var typeNotebook = new CompyterType { Name = "Notebook" };
                    var typeDesktop = new CompyterType { Name = "Desktop" };
                    var typeUltrabook = new CompyterType { Name = "Ultrabook" };

                    db.CompyterTypes.Add(typeNotebook);
                    db.CompyterTypes.Add(typeDesktop);
                    db.CompyterTypes.Add(typeUltrabook);

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "*** Importing computer types ***";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }
    }
}

