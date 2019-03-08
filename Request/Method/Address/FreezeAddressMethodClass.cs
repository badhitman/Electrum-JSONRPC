////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
    public class FreezeAddressMethodClass : AbstractMethodClass
    {
        public override string method => "freeze";
        public string address;
        public FreezeAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            SimpleBoolResponseClass result = new SimpleBoolResponseClass();
            return result.ReadObject(data);
        }
    }
}
