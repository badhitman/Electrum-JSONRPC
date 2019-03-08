////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Трансляция транзакции в сеть
    /// ~ ~ ~
    /// Broadcast a transaction to the network
    /// </summary>
    class BroadcastTransactionToNetworkMethodClass : AbstractMethodClass
    {
        public override string method => "broadcast";

        public string tx;
        public BroadcastTransactionToNetworkMethodClass(Electrum_JSONRPC_Client client)
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
