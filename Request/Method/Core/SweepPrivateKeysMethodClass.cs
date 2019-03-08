////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
    public class SweepPrivateKeysMethodClass : AbstractMethodClass
    {
        public override string method => "sweep";
        public string privkey;
        public string destination;

        public double fee = 0;
        public bool? nocheck = null;
        public int imax = 0;
        
        public SweepPrivateKeysMethodClass(Electrum_JSONRPC_Client client)
            :base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            options.Add("privkey", privkey);
            options.Add("destination", destination);

            if(fee>0)
                options.Add("fee", fee.ToString());

            if (nocheck != null)
                options.Add("nocheck", nocheck.ToString());

            if (imax > 0)
                options.Add("imax", imax.ToString());

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
