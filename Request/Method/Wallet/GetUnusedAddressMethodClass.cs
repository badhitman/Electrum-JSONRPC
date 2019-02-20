////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Возвращает первый неиспользованный адрес Кошелька или нет, если используются все адреса. Адрес считается использованным, если он получил транзакцию или используется в запросе на платеж
    /// ~ ~ ~
    /// Returns the first unused address of the wallet, or None if all addresses are used. An address is considered as used if it has received a transaction, or if it is used in a payment request
    /// </summary>
    class GetUnusedAddressMethodClass : AbstractMethodClass
    {
        public override string method => "getunusedaddress";

        public GetUnusedAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);

            throw new NotImplementedException();
        }
    }
}
