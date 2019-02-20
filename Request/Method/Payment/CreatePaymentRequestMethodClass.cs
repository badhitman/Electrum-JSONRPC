////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Создайте платежный запрос, используя первый неиспользованный адрес Кошелька. Адрес будет считаться использованным после этой операции. Если платеж не получен, адрес будет считаться неиспользованным, если платежное требование будет удалено из кошелька
    /// ~ ~ ~
    /// Create a payment request, using the first unused address of the wallet. The address will be considered as used after this operation. If no payment is received, the address will be considered as unused if the payment request is deleted from the wallet
    /// </summary>
    class CreatePaymentRequestMethodClass : AbstractMethodClass
    {
        public override string method => "addrequest";

        // amount, memo='', expiration=None, force=False

        /// <summary>
        /// Bitcoin amount to request
        /// </summary>
        public int amount;

        /// <summary>
        /// Description of the request
        /// </summary>
        public string memo = null;

        /// <summary>
        /// Time in seconds
        /// </summary>
        public long expiration = 0;

        /// <summary>
        /// Force wallet creation, even if limit is exceeded
        /// </summary>
        public bool force = false;

        public CreatePaymentRequestMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }


        public override object execute(NameValueCollection options)
        {
            options.Add("amount", amount.ToString());
            options.Add("force", force.ToString());

            if (!string.IsNullOrEmpty(memo))
                options.Add("memo", memo);

            if (expiration > 0)
                options.Add("expiration", expiration.ToString());

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
