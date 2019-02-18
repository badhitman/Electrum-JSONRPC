////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Проверка, есть ли адрес в кошельке. Возвращает true, если в кошельке существует адрес
    /// ~ ~ ~
    /// Check if address is in wallet. Return true if and only address is in wallet
    /// </summary>
    class IsAddressMineMethodClass : AbstractMethodClass
    {
        public override string method => "ismine";
        public string address;

        public IsAddressMineMethodClass(Electrum_JSONRPC_Client client)
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