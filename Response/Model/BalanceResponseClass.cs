////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class BalanceResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultAddressBalanceClass result;

        [DataContract]
        public class ResultAddressBalanceClass
        {
            [DataMember]
            public string confirmed { get; set; }

            [DataMember]
            public string unconfirmed { get; set; }
        }
    }
}