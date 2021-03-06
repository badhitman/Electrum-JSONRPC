﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Зашифровать сообщение с помощью открытого ключа. Используйте кавычки, если оно содержит пробелы.
    /// ~ ~ ~
    /// Encrypt a message with a public key. Use quotes if the message contains whitespaces.
    /// </summary>
    public class EncryptMessageMethodClass : AbstractMethodClass // commands.py signature encrypt(self, pubkey, message) -> str:
    {
        public override string method => "encrypt";

        /// <summary>
        /// Public key
        /// </summary>
        [Required]
        public string pubkey;

        /// <summary>
        /// Clear text message. Use quotes if it contains spaces.
        /// </summary>
        [Required]
        public string message;

        public EncryptMessageMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(pubkey))
                throw new ArgumentNullException("pubkey");
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("message");

            options.Add("pubkey", pubkey);
            options.Add("message", message);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
