////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Core
{
    /// <summary>
    /// Подметать секретные ключи. Возвращает транзакцию, которая тратит UTXOs из privkey на адрес назначения. Транзакция не транслируется
    /// ~ ~ ~
    /// Sweep private keys. Returns a transaction that spends UTXOs from privkey to a destination address. The transaction is not broadcasted
    /// </summary>
    public class SweepPrivateKeysMethodClass : AbstractMethodClass // commands.py signature sweep(self, privkey, destination, fee=None, nocheck=False, imax=100):
    {
        public override string method => "sweep";
        
        /// <summary>
        /// Private key. Type '?' to get a prompt.
        /// </summary>
        public string privkey;

        /// <summary>
        /// Bitcoin address, contact or alias
        /// </summary>
        public string destination;

        public double? fee = null;
        public bool? nocheck = null;
        public int? imax = null;

        public SweepPrivateKeysMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (string.IsNullOrWhiteSpace(privkey))
                throw new ArgumentNullException("privkey");
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException("destination");

            options.Add("privkey", privkey);
            options.Add("destination", destination);

            if (fee != null && fee > 0)
                options.Add("fee", fee.ToString());

            if (nocheck != null)
                options.Add("nocheck", nocheck.ToString());

            if (imax != null && imax > 0)
                options.Add("imax", imax.ToString());

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
