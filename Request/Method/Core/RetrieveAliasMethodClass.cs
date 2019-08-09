////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Получить псевдоним. Поиск в списке контактов и для открытой записи DNS псевдонима
    /// ~ ~ ~
    /// Retrieve alias. Lookup in your list of contacts, and for an OpenAlias DNS record
    /// </summary>
    class RetrieveAliasMethodClass : AbstractMethodClass // commands.py signature getalias(self, key):
    {
        public override string method => "getalias";
        /// <summary>
        /// Variable name
        /// </summary>
        public string key;
        public RetrieveAliasMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
