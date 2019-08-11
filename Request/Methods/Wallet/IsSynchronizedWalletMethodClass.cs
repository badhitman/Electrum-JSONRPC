////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Возврат состояния синхронизации Кошелька
    /// ~ ~ ~
    /// return wallet synchronization status
    /// </summary>
    class IsSynchronizedWalletMethodClass : AbstractMethodClass
    {
        public override string method => "is_synchronized";

        public IsSynchronizedWalletMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
