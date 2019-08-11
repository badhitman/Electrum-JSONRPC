////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// Remove all payment requests.
    /// </summary>
    class RemoveAllPaymentRequestsMethodClass : AbstractMethodClass
    {
        public override string method => "clearrequests";

        public RemoveAllPaymentRequestsMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            // Electrum just returns a NULL so we will never know if we succeeded
            return true;
        }
    }
}
