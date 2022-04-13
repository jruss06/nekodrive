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
        private NFSClient nfsClient;

        public void Run()
        {
            nfsClient = new NFSClient(NFSClient.NFSVersion.v3);

            nfsClient.Connect(IPAddress.Parse("127.0.0.1"), 0, 0, 30000, Encoding.ASCII, true, OncRpcProtocols.ONCRPC_TCP);

            var exports = nfsClient.GetExportedDevices();

            foreach (var export in exports) 
            {
                Console.WriteLine(export);

                nfsClient.MountDevice(export);

                ReadExport();
            }

        }

        private void ReadExport()
        {
            Queue<string> qFolders = new Queue<string>();
            qFolders.Enqueue(".");

            while (qFolders.Any())
            {
                var currentFolder = qFolders.Dequeue();

                try
                {
                    var attrib = nfsClient.GetItemAttributes(currentFolder);

                    //check if directory before trying to get items
                    if (attrib.NFSType != NFSLibrary.Protocols.Commons.NFSItemTypes.NFDIR)
                        continue;

                    var children = nfsClient.GetDirectoryItems(currentFolder, true);

                    Console.WriteLine($"{currentFolder} {attrib.Mode.UserAccess}");

                    foreach (var child in children)
                    {
                        qFolders.Enqueue(currentFolder + "/" + child);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not read folder {currentFolder}, {ex.Message}");
                }
            }
        }
    }
}
