////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Получить главный закрытый ключ. Возврат главного закрытого ключа Кошелька
    /// ~ ~ ~
    /// Get master private key. Return your wallet's master private key
    /// </summary>
    class GetMasterPrivateKeyMethodClass : AbstractMethodClass
    {
        public override string method => "getmasterprivate";
        public string password = null;
        public GetMasterPrivateKeyMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
