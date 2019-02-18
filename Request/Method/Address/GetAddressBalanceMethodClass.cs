////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Возврат остатка по любому адресу. Примечание: это-запрос сервера walletless, результаты не проверены SPV.
    /// ~ ~ ~
    /// Return the balance of any address. Note: This is a walletless server query, results are not checked by SPV.
    /// </summary>
    class GetAddressBalanceMethodClass : AbstractMethodClass
    {
        public override string method => "getaddressbalance";
        public string address;

        public GetAddressBalanceMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            BalanceResponseClass result = new BalanceResponseClass();
            return result.ReadObject(data);
        }
    }
}
