////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class SimpleStringArrayArrayResponseClass : AbstractResponseClass
    {
        [DataMember]
        public string[][] result { get; set; }
    }
}
