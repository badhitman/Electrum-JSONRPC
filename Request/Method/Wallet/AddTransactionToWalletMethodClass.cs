////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Add a transaction to the wallet history
    /// </summary>
    class AddTransactionToWalletMethodClass : AbstractMethodClass
    {
        public override string method => "addtransaction";

        public string tx;

        public AddTransactionToWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("tx", tx);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
