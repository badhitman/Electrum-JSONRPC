////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Получить Merkle ветвь транзакции, включенной в блок. Electrum использует это для проверки транзакций (простая проверка платежей)
    /// ~ ~ ~
    /// Get Merkle branch of a transaction included in a block. Electrum uses this to verify transactions (Simple Payment Verification)
    /// </summary>
    class GetMerkleMethodClass : AbstractMethodClass // commands.py signature getmerkle(self, txid, height):
    {
        public override string method => "getmerkle";

        /// <summary>
        /// Transaction ID
        /// </summary>
        [Required]
        public string txid;

        /// <summary>
        /// Block height
        /// </summary>
        [Required]
        public int height;

        public GetMerkleMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(txid))
                throw new ArgumentNullException("txid");

            if (height <= 0)
                throw new ArgumentException("Высота блока должна быть больше нуля", "height");

            options.Add("txid", txid);
            options.Add("height", height.ToString());
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
