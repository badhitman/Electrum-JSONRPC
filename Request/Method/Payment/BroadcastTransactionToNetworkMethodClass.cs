////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    class BroadcastTransactionToNetworkMethodClass : AbstractMethodClass // commands.py signature broadcast(self, tx):
    {
        public override string method => "broadcast";
        /// <summary>
        /// Serialized transaction (hexadecimal)
        /// </summary>
        public string tx;
        public BroadcastTransactionToNetworkMethodClass(Electrum_JSONRPC_Client client)
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
