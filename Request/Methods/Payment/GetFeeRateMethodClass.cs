////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;

namespace ElectrumJSONRPC.Request.Methods.Payment
{
    /// <summary>
    /// Возврат текущей оптимальной ставки платы за килобайт в соответствии с настройками конфигурации или в соответсвии с параметрами
    /// ~ ~ ~
    /// Return current suggested fee rate (in sat/kvByte), according to config settings or supplied parameters
    /// </summary>
    class GetFeeRateMethodClass : AbstractMethodClass // commands.py signature getfeerate(self, fee_method=None, fee_level=None):
    {
        public enum fee_methods { @static, eta, mempool };

        public override string method => "getfeerate";
        public fee_methods? fee_method = null;
        public double? fee_level = null;

        public GetFeeRateMethodClass(Electrum_JSONRPC_Client client) : base(client)
        {

        }

        public override object execute()
        {
            if (fee_method != null)
                options.Add("fee_method", fee_method.ToString());

            string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (fee_level != null)
                options.Add("fee_level", fee_level.ToString().Replace(".", separator).Replace(",", separator));

            string jsonrpc_raw_data = Client.Execute(method, options);
            throw new NotImplementedException("нужно вернуть десереализованный объект из [jsonrpc_raw_data]");
        }
    }
}
