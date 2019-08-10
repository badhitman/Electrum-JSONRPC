////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
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
            jsonrpc_raw_data = Client.Execute(method, options);
            Response.Model.SimpleStringResponseClass result = new Response.Model.SimpleStringResponseClass();
            return result.ReadObject(jsonrpc_raw_data);
        }
    }
}
