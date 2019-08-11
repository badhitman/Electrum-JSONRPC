////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Возврат списка доступных серверов
    /// ~ ~ ~
    /// Return the list of available servers
    /// </summary>
    class GetServersMethodClass : AbstractMethodClass
    {
        public override string method => "getservers";

        public GetServersMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
