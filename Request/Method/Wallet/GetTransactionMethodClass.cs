////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    class GetTransactionMethodClass : AbstractMethodClass // commands.py signature gettransaction(self, txid):
    {
        public override string method => "gettransaction";
        /// <summary>
        /// Transaction ID
        /// </summary>
        public string txid;

        public GetTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("txid", txid);

            string jsonrpc_raw_data = Client.Execute(method, options);
            
            return new GetTransactionResponseClass().ReadObject(jsonrpc_raw_data);
        }
    }
}
