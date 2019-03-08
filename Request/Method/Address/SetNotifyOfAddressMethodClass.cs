////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Следи за адресом. При каждом изменении адреса на URL-адрес отправляется POST http.
    /// ~ ~ ~
    /// Watch an address. Every time the address changes, a http POST is sent to the URL.
    /// </summary>
    class SetNotifyOfAddressMethodClass : AbstractMethodClass
    {
        public override string method => "notify";
        public string address;
        public string URL;

        public SetNotifyOfAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            options.Add("URL", URL);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
