﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace NFSLibrary.Protocols.Commons
{
    public interface INFS
    {
        void Connect(IPAddress Address, int UserID, int GroupID, int ClientTimeout, System.Text.Encoding characterEncoding, bool useSecurePort, int protocol);

        void Disconnect();

        List<String> GetExportedDevices();

        void MountDevice(String DeviceName);

        void UnMountDevice();

        List<String> GetItemList(String DirectoryFullName, NFSAttributes itemAttributes = null);

        NFSAttributes GetItemAttributes(String ItemFullName);

        NFSAttributes Lookup(string itemName, byte[] nFSHandle);

        void CreateDirectory(String DirectoryFullName, NFSPermission Mode);

        void DeleteDirectory(String DirectoryFullName);

        void DeleteFile(String FileFullName);

        void CreateFile(String FileFullName, NFSPermission Mode);

        int Read(String FileFullName, long Offset, int Count, ref byte[] Buffer);

        void SetFileSize(String FileFullName, long Size);

        int Write(String FileFullName, long Offset, int Count, byte[] Buffer);

        void Move(String OldDirectoryFullName, String OldFileName, String NewDirectoryFullName, String NewFileName);

        bool IsDirectory(String DirectoryFullName);

        void CompleteIO();
    }

}
