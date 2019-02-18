////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Return a payment request.
    /// </summary>
    class GetPaymentRequestMethodClass : AbstractMethodClass
    {
        public override string method => "getrequest";
        public string key;

        public GetPaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
