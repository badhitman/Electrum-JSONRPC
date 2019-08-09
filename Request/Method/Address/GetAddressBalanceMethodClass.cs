////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    class GetAddressBalanceMethodClass : AbstractMethodClass // commands.py signature getaddressbalance(self, address):
    {
        public override string method => "getaddressbalance";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;

        public GetAddressBalanceMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            BalanceResponseClass result = new BalanceResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
