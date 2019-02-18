////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ElectrumJSONRPC.exClasses
{
    [DataContract]
    public class JsonSerClass
    {
        DataContractJsonSerializer serializer;
        MemoryStream stream;
        public JsonSerClass()
        {
            serializer = new DataContractJsonSerializer(GetType());
        }

        public override string ToString()
        {
            stream = new MemoryStream();
            serializer.WriteObject(stream, this);
            string res = Encoding.UTF8.GetString(stream.ToArray());
            stream.Close();
            return res;
        }

        public object ReadObject(string json_data)
        {
            if (string.IsNullOrEmpty(json_data))
                return null;

            byte[] byteArray = Encoding.UTF8.GetBytes(json_data);
            stream = new MemoryStream(byteArray)
            {
                Position = 0
            };
            return serializer.ReadObject(stream);
        }
    }
}
