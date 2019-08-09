////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
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
        public string txid;
        /// <summary>
        /// Block height
        /// </summary>
        public int height;
        
        public GetMerkleMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("txid", txid);
            options.Add("height", height.ToString());
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
