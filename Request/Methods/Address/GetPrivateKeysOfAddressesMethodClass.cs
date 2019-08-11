////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Address
{
    /// <summary>
    /// Получить закрытые ключи адресов. Вы можете передать один адрес Кошелька или список адресов Кошелька
    /// ~ ~ ~
    /// Get private keys of addresses. You may pass a single wallet address, or a list of wallet addresses
    /// </summary>
    class GetPrivateKeysOfAddressesMethodClass : AbstractMethodClass // commands.py signature getprivatekeys(self, address, password=None):
    {
        public override string method => "getprivatekeys";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public string password = null;

        public GetPrivateKeysOfAddressesMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
