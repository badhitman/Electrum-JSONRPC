////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Возвращает список UTXO любого адреса. Примечание: это-запрос сервера walletless, результаты не проверены SPV.
    /// ~ ~ ~
    /// Returns the UTXO list of any address. Note: This is a walletless server query, results are not checked by SPV.
    /// </summary>
    class GetAddressUnspentMethodClass : AbstractMethodClass // commands.py signature getaddressunspent(self, address):
    {
        public override string method => "getaddressunspent";
        
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;

        public GetAddressUnspentMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            string jsonrpc_raw_data = Client.Execute(method, options);
            AddressUnspentResponseClass result = new AddressUnspentResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
