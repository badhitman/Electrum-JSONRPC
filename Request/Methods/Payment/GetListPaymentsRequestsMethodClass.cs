////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// List the payment requests you made.
    /// </summary>
    class GetListPaymentsRequestsMethodClass : AbstractMethodClass // commands.py signature listrequests(self, pending=False, expired=False, paid=False):
    {
        public override string method => "listrequests";
        public bool? pending = null;
        public bool? expired = null;
        public bool? paid = null;
        
        public GetListPaymentsRequestsMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (pending != null)
                options.Add("pending", pending.ToString());

            if (expired != null)
                options.Add("expired", expired.ToString());

            if (paid != null)
                options.Add("paid", paid.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
