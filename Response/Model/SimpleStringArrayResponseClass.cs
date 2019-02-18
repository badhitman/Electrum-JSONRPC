////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class SimpleStringArrayResponseClass : AbstractResponseClass
    {
        [DataMember]
        public string[] result { get; set; }
    }
}
