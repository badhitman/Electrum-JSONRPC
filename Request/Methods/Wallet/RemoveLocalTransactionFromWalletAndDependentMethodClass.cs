////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Remove a 'local' transaction from the wallet, and its dependent transactions.
    /// </summary>
    class RemoveLocalTransactionFromWalletAndDependentMethodClass : AbstractMethodClass // commands.py signature removelocaltx(self, txid):
    {
        public override string method => "removelocaltx";
        
        /// <summary>
        /// Transaction ID
        /// </summary>
        [Required]
        public string txid;

        public RemoveLocalTransactionFromWalletAndDependentMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(txid))
                throw new ArgumentNullException("txid");

            options.Add("txid", txid);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
