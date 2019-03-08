////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Возврат состояния синхронизации Кошелька
    /// ~ ~ ~
    /// return wallet synchronization status
    /// </summary>
    class IsSynchronizedWalletMethodClass : AbstractMethodClass
    {
        public override string method => "is_synchronized";

        public IsSynchronizedWalletMethodClass(Electrum_JSONRPC_Client client)
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
