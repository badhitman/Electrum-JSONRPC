////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// Return a payment request.
    /// </summary>
    class GetPaymentRequestMethodClass : AbstractMethodClass // commands.py signature getrequest(self, key):
    {
        public override string method => "getrequest";

        /// <summary>
        /// Идентификатор счёта (in version 3.3.8 take by BTC address)
        /// </summary>
        [Required]
        public string key;

        public GetPaymentRequestMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");

            options.Add("key", key);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
