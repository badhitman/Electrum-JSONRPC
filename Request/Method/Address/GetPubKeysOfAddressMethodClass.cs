////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
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
    class GetPubKeysOfAddressMethodClass : AbstractMethodClass
    {
        public override string method => "getpubkeys";
        public string address;
        public GetPubKeysOfAddressMethodClass(Electrum_JSONRPC_Client client)
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
