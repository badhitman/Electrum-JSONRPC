////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request
{
    abstract public class AbstractMethodClass : MethodInterface
    {
        public abstract object execute(NameValueCollection options);

        public abstract string method { get; }
        protected NameValueCollection request_params = new NameValueCollection();
        protected Electrum_JSONRPC_Client Client = null;
        public string jsonrpc_raw_data { get; protected set; }

        public AbstractMethodClass(Electrum_JSONRPC_Client in_client)
        {
            Client = in_client;
        }
    }
}