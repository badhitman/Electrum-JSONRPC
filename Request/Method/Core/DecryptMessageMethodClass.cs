////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Расшифровка сообщения, зашифрованного с помощью открытого ключа
    /// ~ ~ ~
    /// Decrypt a message encrypted with a public key
    /// </summary>
    public class DecryptMessageMethodClass : AbstractMethodClass
    {
        public override string method => "decrypt";
        
        public string pubkey;
        public string encrypted;
        public string password = null;

        public DecryptMessageMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("pubkey", pubkey);
            options.Add("encrypted", encrypted);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string data = Client.Execute(method, options);

            throw new NotImplementedException();
        }
    }
}
