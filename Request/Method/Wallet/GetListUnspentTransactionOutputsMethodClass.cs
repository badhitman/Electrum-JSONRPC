////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Список неизрасходованных результатов. Возвращает список результатов неизрасходованных транзакций в вашем кошельке
    /// ~ ~ ~
    /// List unspent outputs. Returns the list of unspent transaction outputs in your wallet
    /// </summary>
    class GetListUnspentTransactionOutputsMethodClass : AbstractMethodClass
    {
        public override string method => "listunspent";
        public GetListUnspentTransactionOutputsMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
