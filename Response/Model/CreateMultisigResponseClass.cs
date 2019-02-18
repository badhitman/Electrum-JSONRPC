////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class CreateMultisigResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultCreateMultisigResponseClass result;

        [DataContract]
        public class ResultCreateMultisigResponseClass
        {
            [DataMember]
            public string address { get; set; }

            [DataMember]
            public string redeemScript { get; set; }
        }
    }
}