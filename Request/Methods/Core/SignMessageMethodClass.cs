﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Core
{
    /// <summary>
    /// Sign a message with a key. Use quotes if your message contains whitespaces
    /// </summary>
    public class SignMessageMethodClass : AbstractMethodClass // commands.py signature signmessage(self, address, message, password=None):
    {
        public override string method => "signmessage";

        /// <summary>
        /// Bitcoin address
        /// </summary>
        [Required]
        public string address;

        /// <summary>
        /// Clear text message. Use quotes if it contains spaces.
        /// </summary>
        [Required]
        public string message;

        public string password = null;

        public SignMessageMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            options.Add("address", address);
            options.Add("message", message);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            string jsonrpc_raw_data = Client.Execute(method, options);

            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
