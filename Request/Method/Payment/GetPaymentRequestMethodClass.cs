////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Return a payment request.
    /// </summary>
    class GetPaymentRequestMethodClass : AbstractMethodClass // commands.py signature getrequest(self, key):
    {
        public override string method => "getrequest";
        /// <summary>
        /// Идентификатор счёта
        /// </summary>
        public string key;

        public GetPaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
