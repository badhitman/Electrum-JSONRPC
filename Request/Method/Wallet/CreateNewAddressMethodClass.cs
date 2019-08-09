////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Создайте новый адрес получения, за пределами лимита разрыва Кошелька
    /// ~ ~ ~
    /// Create a new receiving address, beyond the gap limit of the wallet
    /// </summary>
    class CreateNewAddressMethodClass : AbstractMethodClass
    {
        public override string method => "createnewaddress";

        public CreateNewAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            SimpleStringResponseClass result = new SimpleStringResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
