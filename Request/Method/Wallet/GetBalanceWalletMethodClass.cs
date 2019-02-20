////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Return the balance of your wallet
    /// </summary>
    class GetBalanceWalletMethodClass : AbstractMethodClass
    {
        public override string method => "getbalance";

        public GetBalanceWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);
            BalanceResponseClass result = new BalanceResponseClass();
            return result.ReadObject(data);
        }
    }
}