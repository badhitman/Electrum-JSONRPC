////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
using System.Collections.Specialized;

namespace ElectrumJSONRPC.Request
{
    public interface MethodInterface
    {
        object execute(NameValueCollection options);
    }
}
