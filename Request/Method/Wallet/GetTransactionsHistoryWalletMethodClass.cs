////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Wallet history. Returns the transaction history of your wallet
    /// </summary>
    class GetTransactionsHistoryWalletMethodClass : AbstractMethodClass
    {
        public override string method => "history";
        
        public string year = null;
        public bool? show_addresses = null;
        public bool? show_fiat = null;

        public GetTransactionsHistoryWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (!string.IsNullOrEmpty(year))
                options.Add("year", year);

            if(show_addresses != null)
                options.Add("show_addresses", show_addresses.ToString());

            if (show_fiat != null)
                options.Add("show_fiat", show_fiat.ToString());

            string data = Client.Execute(method, options);
            WalletTransactionsHistoryResponseClass result = new WalletTransactionsHistoryResponseClass();
            return result.ReadObject(data);
        }
    }
}
