////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Create a transaction
    /// </summary>
    class CreateTransactionMethodClass : AbstractMethodClass // commands.py signature payto(self, destination, amount, fee=None, from_addr=None, change_addr=None, nocheck=False, unsigned=False, rbf=None, password=None, locktime=None):
    {
        public override string method => "payto";
        
        /// <summary>
        /// Bitcoin address, contact or alias
        /// </summary>
        public string destination;
        
        /// <summary>
        /// Amount to be sent (in BTC). Type '!' to send the maximum available.
        /// </summary>
        public string amount;

        public double? fee = null;
        public string from_addr = null;
        public string change_addr = null;
        public bool? nocheck = null;
        public bool? unsigned = null;
        public string rbf = null;
        public string password = null;
        public string locktime = null;

        public CreateTransactionMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(amount))
                throw new ArgumentNullException("amount");
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException("destination");

            options.Add("amount", amount);
            options.Add(destination, destination);

            if (fee != null && fee > 0)
                options.Add("fee", fee.ToString());

            if (!string.IsNullOrEmpty(from_addr))
                options.Add("from_addr", from_addr);

            if (!string.IsNullOrEmpty(change_addr))
                options.Add("change_addr", change_addr);

            if (nocheck != null)
                options.Add("nocheck", nocheck.ToString());

            if (unsigned != null)
                options.Add("unsigned", unsigned.ToString());

            if (!string.IsNullOrEmpty(rbf))
                options.Add("rbf", rbf);

            if (!string.IsNullOrEmpty(password))
                options.Add("password", password);

            if (!string.IsNullOrEmpty(locktime))
                options.Add("locktime", locktime);

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
