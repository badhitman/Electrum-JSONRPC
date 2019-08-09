////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using ElectrumJSONRPC.exClasses;
using System.Collections.Specialized;
using System.Linq;

namespace ElectrumJSONRPC.Request
{
    public class json_request : JsonSerClass
    {
        public int id;

        public string method;

        public NameValueCollection Request_params;



        public override string ToString()
        {
            string result = "{\"id\":" + id + ", \"method\":\"" + method + "\", \"params\":"+ ToQueryString() + "}";

            return result;
        }

        private string ToQueryString()
        {
            if (Request_params.Count == 0)
                return "[]";

            var array = (from key in Request_params.AllKeys from value in Request_params.GetValues(key) select string.Format("\"{0}\":\"{1}\"", key, value)).ToArray();
            return "{" + string.Join(",", array) + "}";
        }
    }
}
