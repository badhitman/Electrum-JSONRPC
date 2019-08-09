////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Remove all payment requests.
    /// </summary>
    class RemoveAllPaymentRequestsMethodClass : AbstractMethodClass
    {
        public override string method => "clearrequests";

        public RemoveAllPaymentRequestsMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            // Electrum just returns a NULL so we will never know if we succeeded
            return true;
        }
    }
}
