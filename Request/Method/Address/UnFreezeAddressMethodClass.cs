////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Address
{
    /// <summary>
    /// Размаморозить адрес. Размаморозить средства на одном из адресов Вашего кошелька
    /// ~ ~ ~
    /// Unfreeze address. Unfreeze the funds at one of your wallet's addresses
    /// </summary>
    class UnFreezeAddressMethodClass : AbstractMethodClass
    {
        public override string method => "unfreeze";
        public string address;
        public UnFreezeAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
