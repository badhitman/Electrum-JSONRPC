////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Change wallet password
    /// </summary>
    class ChangeWalletPasswordMethodClass : AbstractMethodClass // commands.py signature password(self, password=None, new_password=None):
    {
        public override string method => "password";

        [Required]
        public string password = null;

        [Required]
        public string new_password = null;

        public ChangeWalletPasswordMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            if (!string.IsNullOrEmpty(new_password))
                options.Add("new_password", new_password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
