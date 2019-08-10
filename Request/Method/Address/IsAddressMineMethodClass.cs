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
    /// Проверка, есть ли адрес в кошельке. Возвращает true, если в кошельке существует адрес
    /// ~ ~ ~
    /// Check if address is in wallet. Return true if and only address is in wallet
    /// </summary>
    public class IsAddressMineMethodClass : AbstractMethodClass // commands.py signature ismine(self, address):
    {
        public override string method => "ismine";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;

        public IsAddressMineMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);
            jsonrpc_raw_data = Client.Execute(method, options);
            SimpleBoolResponseClass result = new SimpleBoolResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}