////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
    public class DecryptMessageMethodClass : AbstractMethodClass // commands.py signature decrypt(self, pubkey, encrypted, password=None) -> str:
    {
        public override string method => "decrypt";
        
        /// <summary>
        /// Public key
        /// </summary>
        public string pubkey;
        
        /// <summary>
        /// Encrypted message
        /// </summary>
        public string encrypted;

        public string password = null;

        public DecryptMessageMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(pubkey))
                throw new ArgumentNullException("pubkey");
            if (string.IsNullOrWhiteSpace(encrypted))
                throw new ArgumentNullException("encrypted");

            options.Add("pubkey", pubkey);
            options.Add("encrypted", encrypted);

            if(!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
