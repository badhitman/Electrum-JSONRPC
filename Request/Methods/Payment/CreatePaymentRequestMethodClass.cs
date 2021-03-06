﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Response.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// Создайте платежный запрос, используя первый неиспользованный адрес Кошелька. Адрес будет считаться использованным после этой операции. Если платеж не получен, адрес будет считаться неиспользованным, если платежное требование будет удалено из кошелька
    /// ~ ~ ~
    /// Create a payment request, using the first unused address of the wallet. The address will be considered as used after this operation. If no payment is received, the address will be considered as unused if the payment request is deleted from the wallet
    /// </summary>
    class CreatePaymentRequestMethodClass : AbstractMethodClass // commands.py signature addrequest(self, amount, memo='', expiration=None, force=False):
    {
        public override string method => "addrequest";

        /// <summary>
        /// Amount (in BTC).
        /// </summary>
        [Required]
        public double amount;

        /// <summary>
        /// Description of the request
        /// </summary>
        public string memo = null;

        /// <summary>
        /// Time in seconds
        /// </summary>
        public long? expiration = null;

        /// <summary>
        /// Force wallet creation, even if limit is exceeded
        /// </summary>
        public bool? force = null;

        public CreatePaymentRequestMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть больше нуля", "amount");

            options.Add("amount", amount.ToString());

            if (!string.IsNullOrEmpty(memo))
                options.Add("memo", memo);

            if (expiration != null && expiration > 0)
                options.Add("expiration", expiration.ToString());

            if (force != null)
                options.Add("force", force.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options).Replace("amount (BTC)", "amountBTC");
            CreatePaymentResponseClass result = new CreatePaymentResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
