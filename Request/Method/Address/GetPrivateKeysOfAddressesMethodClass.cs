////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Получить закрытые ключи адресов. Вы можете передать один адрес Кошелька или список адресов Кошелька
    /// ~ ~ ~
    /// Get private keys of addresses. You may pass a single wallet address, or a list of wallet addresses
    /// </summary>
    class GetPrivateKeysOfAddressesMethodClass : AbstractMethodClass
    {
        public override string method => "getprivatekeys";

        public string address;
        public string password = null;

        public GetPrivateKeysOfAddressesMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
