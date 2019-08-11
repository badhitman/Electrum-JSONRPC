////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Address
{
    /// <summary>
    /// Возврат истории транзакций по любому адресу. Примечание: это-запрос сервера walletless, результаты не проверены SPV.
    /// ~ ~ ~
    /// Return the transaction history of any address. Note: This is a walletless server query, results are not checked by SPV.
    /// </summary>
    class GetAddressHistoryMethodClass : AbstractMethodClass // commands.py signature getaddresshistory(self, address):
    {
        public override string method => "getaddresshistory";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        public GetAddressHistoryMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            AddressHistoryResponseClass result = new AddressHistoryResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
