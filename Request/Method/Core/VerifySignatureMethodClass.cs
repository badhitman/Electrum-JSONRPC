////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Verify a signature
    /// </summary>
    public class VerifySignatureMethodClass : AbstractMethodClass // commands.py signature verifymessage(self, address, signature, message):
    {
        public override string method => "verifymessage";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;
        public string signature;
        /// <summary>
        /// Clear text message. Use quotes if it contains spaces.
        /// </summary>
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

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
