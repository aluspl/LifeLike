using Newtonsoft.Json;

namespace LifeLike.Services.ViewModel
{
    public class BaseViewModel
    {
        public override string ToString()
        {
          return  JsonConvert.SerializeObject(this);
        }
    }
}