////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Задайте переменную конфигурации. 'value' может быть строкой или выражением Python
    /// ~ ~ ~
    /// Set a configuration variable. 'value' may be a string or a Python expression
    /// </summary>
    class SetConfigValueMethodClass : AbstractMethodClass // commands.py signature setconfig(self, key, value):
    {
        public override string method => "setconfig";
        /// <summary>
        /// Variable name
        /// </summary>
        public string key;
        public string value;

        public SetConfigValueMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            options.Add("value", value);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
