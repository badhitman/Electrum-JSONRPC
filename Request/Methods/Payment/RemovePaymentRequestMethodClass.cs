////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// Удаление запроса на оплату
    /// ~ ~ ~
    /// Remove a payment request
    /// </summary>
    class RemovePaymentRequestMethodClass : AbstractMethodClass // commands.py signature rmrequest(self, address):
    {
        public override string method => "rmrequest";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public RemovePaymentRequestMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
