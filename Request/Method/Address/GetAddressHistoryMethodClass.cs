////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Возврат истории транзакций по любому адресу. Примечание: это-запрос сервера walletless, результаты не проверены SPV.
    /// ~ ~ ~
    /// Return the transaction history of any address. Note: This is a walletless server query, results are not checked by SPV.
    /// </summary>
    class GetAddressHistoryMethodClass : AbstractMethodClass
    {
        public override string method => "getaddresshistory";
        public string address;

        public GetAddressHistoryMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            AddressHistoryResponseClass result = new AddressHistoryResponseClass();
            return result.ReadObject(data);
        }
    }
}
