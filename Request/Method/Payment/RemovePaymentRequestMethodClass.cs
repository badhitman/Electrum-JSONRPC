////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Удаление запроса на оплату
    /// ~ ~ ~
    /// Remove a payment request
    /// </summary>
    class RemovePaymentRequestMethodClass : AbstractMethodClass
    {
        public override string method => "rmrequest";
        public string address;

        public RemovePaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
