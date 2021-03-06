﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Десериализация сериализованной транзакции
    /// ~ ~ ~
    /// Deserialize a serialized transaction
    /// </summary>
    class DeserializeTransactionMethodClass : AbstractMethodClass // commands.py signature deserialize(self, tx):
    {
        public override string method => "deserialize";

        /// <summary>
        /// Serialized transaction (hexadecimal)
        /// </summary>
        [Required]
        public string tx;

        public DeserializeTransactionMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (string.IsNullOrWhiteSpace(tx))
                throw new ArgumentNullException("tx");

            options.Add("tx", tx);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
