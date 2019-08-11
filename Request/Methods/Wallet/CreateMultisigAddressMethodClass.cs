////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Wallet
{
    /// <summary>
    /// Create multisig address
    /// </summary>
    class CreateMultisigAddressMethodClass : AbstractMethodClass // commands.py signature createmultisig(self, num, pubkeys):
    {
        public override string method => "createmultisig";

        [Required]
        public int num;

        [Required]
        public string pubkeys;

        public CreateMultisigAddressMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (num <= 0)
                throw new ArgumentException("Количество подписей должно быть больше нуля", "num");
            if (string.IsNullOrWhiteSpace(pubkeys))
                throw new ArgumentNullException("pubkeys");

            options.Add("num", num.ToString());
            options.Add("pubkeys", pubkeys);
            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
