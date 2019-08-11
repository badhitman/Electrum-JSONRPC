////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Returns some information regarding the tx. For now, only confirmations. The transaction must be related to the wallet.
    /// </summary>
    class InformationRegardingTxMethodClass : AbstractMethodClass // commands.py signature get_tx_status(self, txid):
    {
        public override string method => "get_tx_status";

        /// <summary>
        /// Transaction ID
        /// </summary>
        [Required]
        public string txid;

        public InformationRegardingTxMethodClass(Electrum_JSONRPC_Client client) : base(client)
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
