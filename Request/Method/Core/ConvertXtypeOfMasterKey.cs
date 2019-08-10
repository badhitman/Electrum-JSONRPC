﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Convert xtype of a master key. e.g. xpub -> ypub
    /// </summary>
    public class ConvertXtypeOfMasterKey : AbstractMethodClass // commands.py signature convert_xkey(self, xkey, xtype):
    {
        public override string method => "convert_xkey";
        public string xkey;
        public string xtype;

        public ConvertXtypeOfMasterKey(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(xkey))
                throw new ArgumentNullException("xkey");
            if (string.IsNullOrWhiteSpace(xtype))
                throw new ArgumentNullException("xtype");

            options.Add("xkey", xkey);
            options.Add("xtype", xtype);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
