////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class SimpleStringResponseClass : AbstractResponseClass
    {
        [DataMember]
        public string result { get; set; }
    }
}
