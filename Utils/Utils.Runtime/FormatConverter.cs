using Newtonsoft.Json;

namespace Utils.Runtime
{
    public static class FormatConverter
    {
        public static string ToJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T FromJson<T>(string c)
        {
            return JsonConvert.DeserializeObject<T>(c);
        }
    }
}
