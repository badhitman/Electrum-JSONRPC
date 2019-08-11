////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Show your list of contacts
    /// </summary>
    public class GetContactsMethodClass : AbstractMethodClass
    {
        public override string method => "listcontacts";

        public GetContactsMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
