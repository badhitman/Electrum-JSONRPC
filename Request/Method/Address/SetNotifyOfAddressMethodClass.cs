////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    public class SetNotifyOfAddressMethodClass : AbstractMethodClass // commands.py signature notify(self, address: str, URL: str):
    {
        public override string method => "notify";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;
        public string URL;

        public SetNotifyOfAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            if (string.IsNullOrWhiteSpace(URL))
                throw new ArgumentNullException("URL");

            options.Add("address", address);
            options.Add("URL", URL);
            jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
