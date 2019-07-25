using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Return a configuration variable.
    /// </summary>
    class GetMethodClass : AbstractMethodClass
    {
        public override string method => "get";
        public string key;
        public GetMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
