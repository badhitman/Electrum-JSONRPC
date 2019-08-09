////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Restore a wallet from text. Text can be a seed phrase, a master
    /// public key, a master private key, a list of bitcoin addresses
    /// or bitcoin private keys.If you want to be prompted for your
    /// seed, type '?' or ':' (concealed)
    /// </summary>
    class RestoreWalletMethodClass : AbstractMethodClass // commands.py signature restore(self, text, passphrase=None, password=None, encrypt_file=True):
    {
        public override string method => "restore";
        public string text;
        public string passphrase = null;
        public string password = null;
        public bool? encrypt_file = null;

        public RestoreWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("text", text);

            if (!string.IsNullOrEmpty(passphrase))
                options.Add("passphrase", passphrase);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            if (encrypt_file != null)
                options.Add("encrypt_file", encrypt_file.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
