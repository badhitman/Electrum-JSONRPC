////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Зашифровать сообщение с помощью открытого ключа. Используйте кавычки, если оно содержит пробелы.
    /// ~ ~ ~
    /// Encrypt a message with a public key. Use quotes if the message contains whitespaces.
    /// </summary>
    public class EncryptMessageMethodClass : AbstractMethodClass
    {
        public override string method => "encrypt";
        
        public string pubkey;
        public string message;

        public EncryptMessageMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("pubkey", pubkey);
            options.Add("message", message);

            string data = Client.Execute(method, options);

            throw new NotImplementedException();
        }
    }
}
