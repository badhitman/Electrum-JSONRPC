////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
    class RetrieveAliasMethodClass : AbstractMethodClass
    {
        public override string method => "getalias";
        public string key;
        public RetrieveAliasMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
