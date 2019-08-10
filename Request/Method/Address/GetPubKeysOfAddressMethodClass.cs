////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Возврат открытых ключей для адреса Кошелька
    /// ~ ~ ~
    /// Return the public keys for a wallet address
    /// </summary>
    public class GetPubKeysOfAddressMethodClass : AbstractMethodClass // commands.py signature getpubkeys(self, address):
    {
        public override string method => "getpubkeys";
        
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;

        public GetPubKeysOfAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
