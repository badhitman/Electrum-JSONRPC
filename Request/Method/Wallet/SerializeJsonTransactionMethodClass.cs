////////////////////////////////////////////////
// © https://github.com/badhitman
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
    class SerializeJsonTransactionMethodClass : AbstractMethodClass
    {
        public override string method => "serialize";
        public string jsontx;
        public SerializeJsonTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("jsontx", jsontx);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
