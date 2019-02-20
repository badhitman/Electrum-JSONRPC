////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Sign a message with a key. Use quotes if your message contains whitespaces
    /// </summary>
    public class SignMessageMethodClass : AbstractMethodClass
    {
        public override string method => "signmessage";
        // message, password=None
        public string address;
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

            string data = Client.Execute(method, options);
            
            throw new NotImplementedException();
        }
    }
}
