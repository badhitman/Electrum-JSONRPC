////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Метка элемента. Элемент может быть биткойн-адрес или идентификатор транзакции
    /// ~ ~ ~
    /// Assign a label to an item. Item may be a bitcoin address or a transaction ID
    /// </summary>
    public class SetLabelItemMethodClass : AbstractMethodClass // commands.py signature setlabel(self, key, label):
    {
        public override string method => "setlabel";

        [Required]
        public string key;

        [Required]
        public string label;

        public SetLabelItemMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentNullException("label");

            options.Add("key", key);
            options.Add("label", label);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
