////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    class AddressUnspentResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultAddressUnspentClass[] result;

        [DataContract]
        public class ResultAddressUnspentClass
        {
            [DataMember]
            public int tx_pos { get; set; }

            [DataMember]
            public string tx_hash { get; set; }

            [DataMember]
            public int height { get; set; }

            [DataMember]
            public int value { get; set; }
        }
    }
}