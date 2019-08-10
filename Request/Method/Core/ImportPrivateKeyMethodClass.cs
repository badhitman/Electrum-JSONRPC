////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Импорт закрытого ключа
    /// ~ ~ ~
    /// Import a private key
    /// </summary>
    class ImportPrivateKeyMethodClass : AbstractMethodClass // commands.py signature importprivkey(self, privkey, password=None):
    {
        public override string method => "importprivkey";

        /// <summary>
        /// Private key. Type '?' to get a prompt.
        /// </summary>
        public string privkey;
        public string password = null;

        public ImportPrivateKeyMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(privkey))
                throw new ArgumentNullException("privkey");

            options.Add("privkey", privkey);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
