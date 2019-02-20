////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Show your list of contacts
    /// </summary>
    public class GetContactsMethodClass : AbstractMethodClass
    {
        public override string method => "listcontacts";

        public GetContactsMethodClass(Electrum_JSONRPC_Client client)
            :base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);
            
            throw new NotImplementedException();
        }
    }
}
