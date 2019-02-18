////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Проверьте правильность адреса
    /// ~ ~ ~
    /// Check that an address is valid
    /// </summary>
    class ValidateAddressMethodClass : AbstractMethodClass
    {
        public override string method => "validateaddress";
        public string address;
        public ValidateAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            return new Response.Model.SimpleBoolResponseClass().ReadObject(data);
        }
    }
}
