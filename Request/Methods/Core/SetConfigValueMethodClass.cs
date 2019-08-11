////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
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
        [Required]
        public string key;

        [Required]
        public string value;

        public SetConfigValueMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }
        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value");

            options.Add("key", key);
            options.Add("value", value);
            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
