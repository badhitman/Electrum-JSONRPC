////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Возвращает первый неиспользованный адрес Кошелька или нет, если используются все адреса. Адрес считается использованным, если он получил транзакцию или используется в запросе на платеж
    /// ~ ~ ~
    /// Returns the first unused address of the wallet, or None if all addresses are used. An address is considered as used if it has received a transaction, or if it is used in a payment request
    /// </summary>
    class GetUnusedAddressMethodClass : AbstractMethodClass
    {
        public override string method => "getunusedaddress";

        public GetUnusedAddressMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
