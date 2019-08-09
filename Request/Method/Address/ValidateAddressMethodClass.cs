////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Проверьте правильность адреса
    /// ~ ~ ~
    /// Check that an address is valid
    /// </summary>
    class ValidateAddressMethodClass : AbstractMethodClass // commands.py signature validateaddress(self, address):
    {
        public override string method => "validateaddress";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;
        public ValidateAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            return new Response.Model.SimpleBoolResponseClass().ReadObject(jsonrpc_raw_data);
        }
    }
}
