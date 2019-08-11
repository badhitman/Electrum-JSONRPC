////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Convert xtype of a master key. e.g. xpub -> ypub
    /// </summary>
    public class ConvertXtypeOfMasterKeyMethodClass : AbstractMethodClass // commands.py signature convert_xkey(self, xkey, xtype):
    {
        public override string method => "convert_xkey";

        [Required]
        public string xkey;

        [Required]
        public string xtype;

        public ConvertXtypeOfMasterKeyMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
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
