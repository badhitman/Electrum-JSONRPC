////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Address
{
    /// <summary>
    /// Проверьте правильность адреса
    /// ~ ~ ~
    /// Check that an address is valid
    /// </summary>
    public class ValidateAddressMethodClass : AbstractMethodClass // commands.py signature validateaddress(self, address):
    {
        public override string method => "validateaddress";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public ValidateAddressMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if(string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            jsonrpc_raw_data = Client.Execute(method, options);
            return new Response.Model.SimpleBoolResponseClass().ReadObject(jsonrpc_raw_data);
        }
    }
}
