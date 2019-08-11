////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Получить seed фразу. Печать seed Вашего кошелька
    /// ~ ~ ~
    /// Get seed phrase. Print the generation seed of your wallet
    /// </summary>
    class GetSeedPhraseMethodClass : AbstractMethodClass // commands.py signature getseed(self, password=None):
    {
        public override string method => "getseed";
        public string password = null;
        public GetSeedPhraseMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
