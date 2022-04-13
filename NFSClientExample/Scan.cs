using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NFSLibrary;
using org.acplt.oncrpc;

namespace NFSClientExample
{
    public class Scan
    {
        public void Run()
        {
            var client = new NFSClient(NFSClient.NFSVersion.v3);

            client.Connect(IPAddress.Parse("127.0.0.1"), 0, 0, 30000, Encoding.ASCII, true, OncRpcProtocols.ONCRPC_TCP);

            var exports = client.GetExportedDevices();

            foreach (var export in exports) 
            {
                Console.WriteLine(export);

                client.MountDevice(export);

                var children = client.GetDirectoryItems(".");

                foreach (var child in children)
                {
                    var attrib = client.GetItemAttributes(child);

                    Console.WriteLine(child);
                    Console.WriteLine(attrib.Mode.UserAccess);
                }
            }

        }
    }
}
