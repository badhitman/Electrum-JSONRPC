////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Список адресов кошельков. Возвращает список всех адресов в вашем кошельке. Используйте необязательные аргументы для фильтрации результатов
    /// ~ ~ ~
    /// List wallet addresses. Returns the list of all addresses in your wallet. Use optional arguments to filter the results
    /// </summary>
    class GetListWalletAddressesMethodClass : AbstractMethodClass // commands.py signature listaddresses(self, receiving=False, change=False, labels=False, frozen=False, unused=False, funded=False, balance=False):
    {
        public override string method => "listaddresses";

        public bool? receiving = null;
        public bool? change = null;
        public bool? frozen = null;
        public bool? unused = null;
        public bool? funded = null;
        public bool? balance = null;
        public bool? labels = null;

        public GetListWalletAddressesMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (receiving != null)
                options.Add("receiving", receiving.ToString());

            if (change != null)
                options.Add("change", change.ToString());

            if (frozen != null)
                options.Add("frozen", frozen.ToString());

            if (unused != null)
                options.Add("unused", unused.ToString());

            if (funded != null)
                options.Add("funded", funded.ToString());

            if (labels != null)
                options.Add("labels", labels.ToString());

            if (balance != null)
                options.Add("balance", balance.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            
            if ((balance ==  null || balance == false) && (labels == null || labels == false))
                return new SimpleStringArrayResponseClass().ReadObject(jsonrpc_raw_data);
            else
                return new SimpleStringArrayArrayResponseClass().ReadObject(jsonrpc_raw_data);
        }
    }
}
