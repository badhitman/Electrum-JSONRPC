////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Получение транзакции
    /// ~ ~ ~
    /// Retrieve a transaction
    /// </summary>
    class GetTransactionMethodClass : AbstractMethodClass
    {
        public override string method => "gettransaction";

        public string txid;

        public GetTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("txid", txid);

            string data = Client.Execute(method, options);
            
            return new GetTransactionResponseClass().ReadObject(data);
        }
    }
}
