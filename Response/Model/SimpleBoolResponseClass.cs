////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class SimpleBoolResponseClass : AbstractResponseClass
    {
        [DataMember]
        public bool? result { get; set; }
    }
}
