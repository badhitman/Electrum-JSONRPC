////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
