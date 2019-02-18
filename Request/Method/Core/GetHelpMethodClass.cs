////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// for the python console
    /// </summary>
    class GetHelpMethodClass : AbstractMethodClass
    {
        public override string method => "help";
        public GetHelpMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
