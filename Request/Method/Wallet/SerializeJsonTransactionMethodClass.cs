////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Создать транзакцию из json входов. Входы должны иметь redeemPubkey. Выходы должны быть список {'address':address, 'value':satoshi_amount}
    /// ~ ~ ~
    /// Create a transaction from json inputs. Inputs must have a redeemPubkey. Outputs must be a list of {'address':address, 'value':satoshi_amount}
    /// </summary>
    class SerializeJsonTransactionMethodClass : AbstractMethodClass // commands.py signature serialize(self, jsontx):
    {
        public override string method => "serialize";
        public string jsontx;

        public SerializeJsonTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(jsontx))
                throw new ArgumentNullException("jsontx");

            options.Add("jsontx", jsontx);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
