////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
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

        public AbstractMethodClass(Electrum_JSONRPC_Client in_client)
        {
            Client = in_client;
        }
    }
}