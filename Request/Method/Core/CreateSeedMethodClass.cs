////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Create a seed
    /// </summary>
    class CreateSeedMethodClass : AbstractMethodClass
    {
        public override string method => "make_seed";

        public int nbits = 0;
        public string language = null;
        public bool? segwit = null;

        public CreateSeedMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }
        public override object execute(NameValueCollection options)
        {
            if (nbits > 0)
                options.Add("nbits", nbits.ToString());

            if (!string.IsNullOrEmpty(language))
                options.Add("language", language);

            if (segwit != null)
                options.Add("segwit", segwit.ToString());

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
