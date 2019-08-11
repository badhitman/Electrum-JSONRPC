////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Поиск по контактам, возврат совпадающих записей
    /// ~ ~ ~
    /// Search through contacts, return matching entries
    /// </summary>
    class SearchThroughContactsMethodClass : AbstractMethodClass // searchcontacts(self, query):
    {
        public override string method => "searchcontacts";

        [Required]
        public string query;

        public SearchThroughContactsMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException("query");

            options.Add("query", query);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
