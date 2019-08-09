////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
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
        public string address;
        public FreezeAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            SimpleBoolResponseClass result = new SimpleBoolResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
