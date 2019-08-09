////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Sign a message with a key. Use quotes if your message contains whitespaces
    /// </summary>
    public class SignMessageMethodClass : AbstractMethodClass // commands.py signature signmessage(self, address, message, password=None):
    {
        public override string method => "signmessage";
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;
        /// <summary>
        /// Clear text message. Use quotes if it contains spaces.
        /// </summary>
        public string message;
        public string password = null;

        public SignMessageMethodClass(Electrum_JSONRPC_Client client)
            :base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);
            options.Add("message", message);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
