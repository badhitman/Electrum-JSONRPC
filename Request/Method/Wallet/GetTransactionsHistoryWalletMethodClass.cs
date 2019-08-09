////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Wallet history. Returns the transaction history of your wallet
    /// </summary>
    class GetTransactionsHistoryWalletMethodClass : AbstractMethodClass // commands.py signature history(self, year=None, show_addresses=False, show_fiat=False, show_fees=False, from_height=None, to_height=None):
    {
        public override string method => "history";
        public int? year = null;
        public bool? show_addresses = null;
        public bool? show_fiat = null;
        public bool? show_fees = null;
        public long? from_height = null;
        public long? to_height = null;

        public GetTransactionsHistoryWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (year != null)
                options.Add("year", year.ToString());

            if (show_addresses != null)
                options.Add("show_addresses", show_addresses.ToString());

            if (show_fiat != null)
                options.Add("show_fiat", show_fiat.ToString());

            if (show_fees != null)
                options.Add("show_fees", show_fees.ToString());

            if (from_height != null)
                options.Add("from_height", from_height.ToString());

            if (to_height != null)
                options.Add("to_height", to_height.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            WalletTransactionsHistoryResponseClass result = new WalletTransactionsHistoryResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
