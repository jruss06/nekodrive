/*
 * Automatically generated by jrpcgen 1.0.7 on 27/08/2010
 * jrpcgen is part of the "Remote Tea.Net" ONC/RPC package for C#
 * See http://remotetea.sourceforge.net for details
 */
using System;
using org.acplt.oncrpc;

namespace NFSLibrary.Protocols.Commons
{
    public class NFSAttributes
    {
        private DateTime _cdateTime;
        private DateTime _adateTime;
        private DateTime _mdateTime;
        private NFSItemTypes _type;
        private NFSPermission _mode;
        private long _size;
        private Byte[] _handle;
        public int Uid { get; set; }
        public int Gid { get; set; }

        public NFSAttributes(int cdateTime, int adateTime, int mdateTime, NFSItemTypes type, NFSPermission mode, long size, Byte[] handle)
        {
            this._cdateTime = new System.DateTime(1970, 1, 1).AddSeconds(cdateTime);
            this._adateTime = new System.DateTime(1970, 1, 1).AddSeconds(adateTime);
            this._mdateTime = new System.DateTime(1970, 1, 1).AddSeconds(mdateTime);
            this._type = type;
            this._size = size;
            this._mode = mode;
            this._handle = (Byte[])handle.Clone();
        }

        public DateTime CreateDateTime
        {
            get
            { return this._cdateTime; }
        }

        public DateTime LastAccessedDateTime
        {
            get
            { return this._adateTime; }
        }

        public DateTime ModifiedDateTime
        {
            get
            { return this._mdateTime; }
        }

        public NFSItemTypes NFSType
        {
            get
            { return this._type; }
        }

        public NFSPermission Mode
        {
            get
            { return this._mode; }
        }

        public long Size
        {
            get
            { return this._size; }
        }

        public Byte[] Handle
        {
            get
            { return this._handle; }
        }

        public override string ToString()
        {
            System.Text.StringBuilder HandleString = new System.Text.StringBuilder();

            for (int bC = 0; bC < Handle.Length; bC++)
            { HandleString.Append(((Byte)Handle.GetValue(bC)).ToString("X")); }

            return String.Format("CDateTime: {0}, ADateTime: {1}, MDateTime: {2}, Type: {3}, Mode: {4}{5}{6}, Size: {7}, Handle: {8}",
                        CreateDateTime.ToString(), LastAccessedDateTime.ToString(), ModifiedDateTime.ToString(), NFSType.ToString(), Mode.UserAccess, Mode.GroupAccess, Mode.OtherAccess, Size, HandleString.ToString());
        }
    }
}