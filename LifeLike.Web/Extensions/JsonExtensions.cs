using Newtonsoft.Json;

namespace LifeLike.Web.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJSON(this object item)
        {
          return  JsonConvert.SerializeObject(item);
        }
    }
}