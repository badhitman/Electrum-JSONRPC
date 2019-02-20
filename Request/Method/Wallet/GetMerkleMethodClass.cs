////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
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
    class GetMerkleMethodClass : AbstractMethodClass
    {
        public override string method => "getmerkle";
        public string txid;
        public int height;
        
        public GetMerkleMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("txid", txid);
            options.Add("height", height.ToString());
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
