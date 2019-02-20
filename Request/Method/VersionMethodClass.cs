////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request.Method
{
    /// <summary>
    /// Return the version of Electrum.
    /// </summary>
    public class VersionMethodClass : AbstractMethodClass
    {
        public override string method => "version";

        public VersionMethodClass(Electrum_JSONRPC_Client client)
            :base(client)
        {

        }

        public override object execute(NameValueCollection options)
        {
            string data = Client.Execute(method, options);
            Response.Model.SimpleStringResponseClass result = new Response.Model.SimpleStringResponseClass();
            return result.ReadObject(data);
        }
    }
}
