using System;
using System.IO;
using ComputersConfigutarions.Data;

namespace ComputerConfigurations.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<ComputerConfigurationsSystemEntities, TextWriter> Get { get; }
    }
}