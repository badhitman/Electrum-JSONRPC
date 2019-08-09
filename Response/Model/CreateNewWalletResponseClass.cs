////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{ // Create a new wallet
    [DataContract]
    public class CreateNewWalletResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultCreateNewWalletResponseClass result;

        [DataContract]
        public class ResultCreateNewWalletResponseClass
        {
            /// <summary>
            /// Seed phrase
            /// </summary>
            [DataMember]
            public string seed { get; set; }

            [DataMember]
            public string path { get; set; }

            [DataMember]
            public string msg { get; set; }
        }
    }
}