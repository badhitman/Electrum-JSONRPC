////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Add a transaction to the wallet history
    /// </summary>
    class AddTransactionToWalletMethodClass : AbstractMethodClass // commands.py signature addtransaction(self, tx):
    {
        public override string method => "addtransaction";
        /// <summary>
        /// Serialized transaction (hexadecimal)
        /// </summary>
        public string tx;

        public AddTransactionToWalletMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("tx", tx);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
