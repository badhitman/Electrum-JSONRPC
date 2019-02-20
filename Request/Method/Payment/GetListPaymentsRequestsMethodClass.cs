////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// List the payment requests you made.
    /// </summary>
    class GetListPaymentsRequestsMethodClass : AbstractMethodClass
    {
        public override string method => "listrequests";
        public bool? pending = null;
        public bool? expired = null;
        public bool? paid = null;
        
        public GetListPaymentsRequestsMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (pending != null)
                options.Add("pending", pending.ToString());

            if (expired != null)
                options.Add("expired", expired.ToString());

            if (paid != null)
                options.Add("paid", paid.ToString());

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
