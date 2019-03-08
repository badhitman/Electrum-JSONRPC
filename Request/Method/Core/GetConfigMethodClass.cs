////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Return a configuration variable
    /// </summary>
    class GetConfigMethodClass : AbstractMethodClass
    {
        public override string method => "getconfig";
        public string key;
        public GetConfigMethodClass(Electrum_JSONRPC_Client client)
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
