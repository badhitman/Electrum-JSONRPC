////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Create multisig address
    /// </summary>
    class CreateMultisigAddressMethodClass : AbstractMethodClass
    {
        public override string method => "createmultisig";
        public string num;
        public string pubkeys;
        public CreateMultisigAddressMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("num", num);
            options.Add("pubkeys", pubkeys);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
