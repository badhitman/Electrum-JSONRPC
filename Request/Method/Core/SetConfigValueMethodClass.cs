////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
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
    class SetConfigValueMethodClass : AbstractMethodClass
    {
        public override string method => "setconfig";

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
            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
