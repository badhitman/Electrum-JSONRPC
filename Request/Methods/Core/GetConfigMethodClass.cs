////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Return a configuration variable
    /// </summary>
    class GetConfigMethodClass : AbstractMethodClass // commands.py signature getconfig(self, key):
    {
        public override string method => "getconfig";

        /// <summary>
        /// Variable name
        /// </summary>
        [Required]
        public string key;

        public GetConfigMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");

            options.Add("key", key);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
