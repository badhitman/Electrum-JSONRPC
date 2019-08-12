////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    public class CreatePaymentResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultCreatePaymentClass result;

        [DataContract]
        public class ResultCreatePaymentClass
        {
            [DataMember]
            public long?  time{ get; set; }

            [DataMember]
            public string  amount{ get; set; }

            [DataMember]
            public long? exp { get; set; }

            [DataMember]
            public string address { get; set; }

            [DataMember]
            public string memo { get; set; }

            [DataMember]
            public string id { get; set; }

            [DataMember]
            public string URI { get; set; }

            [DataMember]
            public string status { get; set; }

            [DataMember]
            public string amountBTC { get; set; }
        }
    }
}
