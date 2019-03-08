////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using System;
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method.Payment
{
    /// <summary>
    /// Возврат текущей оптимальной ставки платы за килобайт в соответствии с настройками конфигурации или в соответсвии с параметрами
    /// ~ ~ ~
    /// Return current suggested fee rate (in sat/kvByte), according to config settings or supplied parameters
    /// </summary>
    class GetFeeRateMethodClass : AbstractMethodClass
    {
        public enum fee_methods { _static, m_eta, m_mempool };
        public override string method => "getfeerate";
        public fee_methods? fee_method = null;
        public double fee_level = 0;
        //fee_method=None, fee_level=None
        public GetFeeRateMethodClass(Electrum_JSONRPC_Client client)
            : base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            if (fee_method != null)
                options.Add("fee_method", fee_method.ToString());
            string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (fee_level != 0)
                options.Add("fee_level", fee_level.ToString().Replace(".", separator).Replace(",", separator));

            string data = Client.Execute(method, options);
            throw new NotImplementedException();
        }
    }
}
