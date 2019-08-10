////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Подписать сделку. Ключи Кошелька будут использоваться, если не будет предоставлен закрытый ключ
    /// ~ ~ ~
    /// Sign a transaction. The wallet keys will be used unless a private key is provided
    /// </summary>
    class SignTransactionMethodClass : AbstractMethodClass // commands.py signature signtransaction(self, tx, privkey=None, password=None):
    {
        public override string method => "signtransaction";
        
        /// <summary>
        /// Serialized transaction (hexadecimal)
        /// </summary>
        public string tx;
        
        /// <summary>
        /// Private key. Type '?' to get a prompt.
        /// </summary>
        public string privkey = null;
        public string password = null;

        public SignTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(tx))
                throw new ArgumentNullException("tx");

            options.Add("tx", tx);

            if (!string.IsNullOrEmpty(privkey))
                options.Add("privkey", privkey);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
