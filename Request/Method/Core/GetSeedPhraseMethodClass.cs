////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Получить seed фразу. Печать seed Вашего кошелька
    /// ~ ~ ~
    /// Get seed phrase. Print the generation seed of your wallet
    /// </summary>
    class GetSeedPhraseMethodClass : AbstractMethodClass
    {
        public override string method => "getseed";
        public string password = null;
        public GetSeedPhraseMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
