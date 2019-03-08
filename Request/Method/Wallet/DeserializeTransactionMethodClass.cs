////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Десериализация сериализованной транзакции
    /// ~ ~ ~
    /// Deserialize a serialized transaction
    /// </summary>
    class DeserializeTransactionMethodClass : AbstractMethodClass
    {
        public override string method => "deserialize";
        public string tx;
        public DeserializeTransactionMethodClass(Electrum_JSONRPC_Client client)
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
