////////////////////////////////////////////////
// © https://github.com/badhitman
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
    class SignTransactionMethodClass : AbstractMethodClass
    {
        public override string method => "signtransaction";
        public string tx;
        public string privkey = null;
        public string password = null;

        public SignTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("tx", tx);

            if (!string.IsNullOrEmpty(privkey))
                options.Add("privkey", privkey);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            throw new NotImplementedException();
        }
    }
}
