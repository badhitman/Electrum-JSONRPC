////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response
{
    [DataContract]
    public abstract class AbstractResponseClass : exClasses.JsonSerClass
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public ErrorResponseClass error { get; set; }

        public static double DoubleValue(string str_value)
        {
            if (str_value.Length < 5 || str_value.Substring(str_value.Length - 3).ToUpper() != "BTC")
                return 0;

            System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
            return System.Convert.ToDouble(str_value.Replace(".", nfi.CurrencyDecimalSeparator).Replace(",", nfi.CurrencyDecimalSeparator).Substring(0, str_value.Length - 4));
        }
    }

    [DataContract]
    public class ErrorResponseClass
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string message { get; set; }
    }
}
