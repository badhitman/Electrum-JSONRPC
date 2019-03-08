////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Wallet
{
    /// <summary>
    /// Подписать платежный запрос OpenAlias
    /// ~ ~ ~
    /// Sign payment request with an OpenAlias
    /// </summary>
    class SignPaymentRequestMethodClass : AbstractMethodClass
    {
        public override string method => "signrequest";
        public string address;
        public string password = null;
        public SignPaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("address", address);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
