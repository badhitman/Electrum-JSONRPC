////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class AddressHistoryResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultAddressHistoryResponseClass[] result;

        [DataContract]
        public class ResultAddressHistoryResponseClass
        {
            [DataMember]
            public string tx_hash { get; set; }

            [DataMember]
            public int height { get; set; }
        }
    }
}