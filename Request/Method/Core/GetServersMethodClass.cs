////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Возврат списка доступных серверов
    /// ~ ~ ~
    /// Return the list of available servers
    /// </summary>
    class GetServersMethodClass : AbstractMethodClass
    {
        public override string method => "getservers";
        public GetServersMethodClass(Electrum_JSONRPC_Client client)
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
