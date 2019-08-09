////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Create a new wallet
    /// If you want to be prompted for an argument, type '?' or ':' (concealed)
    /// </summary>
    class CreateWalletMethodClass : AbstractMethodClass // commands.py signature create(self, passphrase=None, password=None, encrypt_file=True, segwit=False):
    {
        public override string method => "create";
        public string passphrase = null;
        public string password = null;
        public bool? encrypt_file = true;
        public bool? segwit = false;

        public CreateWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (!string.IsNullOrEmpty(passphrase))
                options.Add("passphrase", passphrase);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            if (encrypt_file != null)
                options.Add("encrypt_file", encrypt_file.ToString());

            if (segwit != null)
                options.Add("segwit", segwit.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
