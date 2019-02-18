////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request
{
    public interface MethodInterface
    {
        object execute(NameValueCollection options);
    }
}
