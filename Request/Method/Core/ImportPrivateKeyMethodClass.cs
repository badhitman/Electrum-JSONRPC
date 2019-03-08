////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
    class ImportPrivateKeyMethodClass : AbstractMethodClass
    {
        public override string method => "importprivkey";
        public string password = null;
        public string privkey;

        public ImportPrivateKeyMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("privkey", privkey);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
