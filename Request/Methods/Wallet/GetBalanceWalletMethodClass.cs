////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Return the balance of your wallet
    /// </summary>
    class GetBalanceWalletMethodClass : AbstractMethodClass
    {
        public override string method => "getbalance";

        public GetBalanceWalletMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            BalanceResponseClass result = new BalanceResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}