////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using MultiTool;
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

        public static double BtcStringDoubleValue(string str_value)
        {
            if (str_value.Length > 5 && str_value.Substring(str_value.Length - 3).ToUpper() == "BTC")
                str_value = str_value.Substring(0, str_value.Length-3).Trim();

            return glob_tools.GetDoubleFromString(str_value);
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
