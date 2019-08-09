////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Поиск по контактам, возврат совпадающих записей
    /// ~ ~ ~
    /// Search through contacts, return matching entries
    /// </summary>
    class SearchThroughContactsMethodClass : AbstractMethodClass
    {
        public override string method => "searchcontacts";
        public string query;
        public SearchThroughContactsMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("query", query);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
