////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Create a transaction
    /// </summary>
    class CreateTransactionMethodClass : AbstractMethodClass
    {
        public override string method => "payto";
        public string amount;
        public string destination;
        // destination, amount, fee=None, from_addr=None, change_addr=None, nocheck=False, unsigned=False, rbf=None, password=None, locktime=None
        public double fee = 0;
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
            options.Add("amount", amount);
            options.Add(destination, destination);

            if (fee > 0)
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

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
