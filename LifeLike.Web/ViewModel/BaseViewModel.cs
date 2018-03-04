using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;

namespace LifeLike.Web.ViewModel
{
    public class BaseViewModel
    {
        public override string ToString()
        {
          return  JsonConvert.SerializeObject(this);
        }
    }
}