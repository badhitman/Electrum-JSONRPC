////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Получить мастер-ключ. Возврат главного открытого ключа Кошелька
    /// ~ ~ ~
    /// Get master public key. Return your wallet's master public key
    /// </summary>
    class GetMpkMethodClass : AbstractMethodClass
    {
        public override string method => "getmpk";
        public GetMpkMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
