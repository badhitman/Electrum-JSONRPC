////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Список неизрасходованных результатов. Возвращает список результатов неизрасходованных транзакций в вашем кошельке
    /// ~ ~ ~
    /// List unspent outputs. Returns the list of unspent transaction outputs in your wallet
    /// </summary>
    class GetListUnspentTransactionOutputsMethodClass : AbstractMethodClass
    {
        public override string method => "listunspent";

        public GetListUnspentTransactionOutputsMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
