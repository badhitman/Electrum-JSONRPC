////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
            /// <summary>
            /// Bitcoin address
            /// </summary>
            [DataMember]
            public string address { get; set; }

            [DataMember]
            public string redeemScript { get; set; }
        }
    }
}