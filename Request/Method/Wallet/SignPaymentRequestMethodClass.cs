////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    class SignPaymentRequestMethodClass : AbstractMethodClass // commands.py signature signrequest(self, address, password=None):
    {
        public override string method => "signrequest";
        
        /// <summary>
        /// Bitcoin address
        /// </summary>
        public string address;
        public string password = null;
        public SignPaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            options.Add("address", address);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
