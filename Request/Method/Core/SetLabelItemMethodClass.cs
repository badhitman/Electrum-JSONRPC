////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Метка элемента. Элемент может быть биткойн-адрес или идентификатор транзакции
    /// ~ ~ ~
    /// Assign a label to an item. Item may be a bitcoin address or a transaction ID
    /// </summary>
    public class SetLabelItemMethodClass : AbstractMethodClass
    {
        public override string method => "setlabel";
        public string key;
        public string label;
        // key, label

        public SetLabelItemMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("key", key);
            options.Add("label", label);

            string data = Client.Execute(method, options);

            return null;
        }
    }
}
