////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Возвращает список UTXO любого адреса. Примечание: это-запрос сервера walletless, результаты не проверены SPV.
    /// ~ ~ ~
    /// Returns the UTXO list of any address. Note: This is a walletless server query, results are not checked by SPV.
    /// </summary>
    class GetAddressUnspentMethodClass : AbstractMethodClass
    {
        public override string method => "getaddressunspent";
        public string address;

        public GetAddressUnspentMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            AddressUnspentResponseClass result = new AddressUnspentResponseClass();
            return result.ReadObject(data);
        }
    }
}
