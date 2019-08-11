////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Получить главный закрытый ключ. Возврат главного закрытого ключа Кошелька
    /// ~ ~ ~
    /// Get master private key. Return your wallet's master private key
    /// </summary>
    class GetMasterPrivateKeyMethodClass : AbstractMethodClass // commands.py signature getmasterprivate(self, password=None):
    {
        public override string method => "getmasterprivate";
        public string password = null;
        public GetMasterPrivateKeyMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
