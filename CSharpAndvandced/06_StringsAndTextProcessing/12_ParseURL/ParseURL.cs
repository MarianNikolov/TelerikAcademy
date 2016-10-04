using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ParseURL
{
    static void Main()
    {

        string input = Console.ReadLine();

        int indexForProtocol = input.IndexOf("://");
        string protocol = input.Substring(0, indexForProtocol);

        int startIndexForServer = input.IndexOf("://") + 3;
        int lastIndexOfServer = input.IndexOf("/", startIndexForServer);
        int lenghtOfServer = lastIndexOfServer - startIndexForServer;
        string server = input.Substring(startIndexForServer, lenghtOfServer);

        int startIndexOfresource = lenghtOfServer + startIndexForServer;
        string resource = input.Substring(startIndexOfresource);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);

    }
}

