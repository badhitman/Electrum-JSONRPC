////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Change wallet password
    /// </summary>
    class ChangeWalletPasswordMethodClass : AbstractMethodClass
    {
        public override string method => "password";

        public string current_password = null;
        public string new_password = null;

        public ChangeWalletPasswordMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (!string.IsNullOrEmpty(current_password))
                options.Add("password", current_password);

            if (!string.IsNullOrEmpty(new_password))
                options.Add("new_password", new_password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
