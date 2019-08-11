////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Address
{
    /// <summary>
    /// Заморозить адрес. Заморозить средства на одном из адресов Вашего кошелька
    /// ~ ~ ~
    /// Freeze address. Freeze the funds at one of your wallet's addresses
    /// </summary>
    public class FreezeAddressMethodClass : AbstractMethodClass // commands.py signature freeze(self, address):
    {
        public override string method => "freeze";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public FreezeAddressMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            SimpleBoolResponseClass result = new SimpleBoolResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
