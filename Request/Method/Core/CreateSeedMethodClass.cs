////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Create a seed
    /// </summary>
    class CreateSeedMethodClass : AbstractMethodClass // commands.py signature make_seed(self, nbits=132, language=None, segwit=False):
    {
        public override string method => "make_seed";

        public int? nbits = null;
        public string language = null;
        public bool? segwit = null;

        public CreateSeedMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (nbits != null && nbits > 0)
                options.Add("nbits", nbits.ToString());

            if (!string.IsNullOrEmpty(language))
                options.Add("language", language);

            if (segwit != null)
                options.Add("segwit", segwit.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
