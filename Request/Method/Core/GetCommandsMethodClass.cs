////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// List of commands
    /// </summary>
    class GetCommandsMethodClass : AbstractMethodClass
    {
        public override string method => "commands";
        public GetCommandsMethodClass(Electrum_JSONRPC_Client client)
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
