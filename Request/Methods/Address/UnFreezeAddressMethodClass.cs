////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Address
{
    /// <summary>
    /// Размаморозить адрес. Размаморозить средства на одном из адресов Вашего кошелька
    /// ~ ~ ~
    /// Unfreeze address. Unfreeze the funds at one of your wallet's addresses
    /// </summary>
    public class UnFreezeAddressMethodClass : AbstractMethodClass // commands.py signature unfreeze(self, address):
    {
        public override string method => "unfreeze";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public UnFreezeAddressMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
