////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class RestoreWalletResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultRestoreWalletResponseClass result;

        [DataContract]
        public class ResultRestoreWalletResponseClass
        {
            [DataMember]
            public string path { get; set; }

            [DataMember]
            public string msg { get; set; }
        }
    }
}