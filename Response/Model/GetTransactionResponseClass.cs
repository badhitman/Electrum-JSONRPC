////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class GetTransactionResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultGetTransactionResponseClass result;


        [DataContract]
        public class ResultGetTransactionResponseClass
        {
            [DataMember]
            public bool final { get; set; }

            [DataMember]
            public string hex { get; set; }

            [DataMember]
            public bool complete { get; set; }
        }
    }
}
