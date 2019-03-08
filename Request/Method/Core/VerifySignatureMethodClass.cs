////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Verify a signature
    /// </summary>
    public class VerifySignatureMethodClass : AbstractMethodClass
    {
        public override string method => "verifymessage";
        public string address;
        public string signature;
        public string message;

        public VerifySignatureMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            options.Add("signature", signature);
            options.Add("message", message);

            string data = Client.Execute(method, options);

            throw new NotImplementedException();
        }
    }
}
