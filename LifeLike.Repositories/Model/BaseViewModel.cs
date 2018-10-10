using Newtonsoft.Json;

namespace LifeLike.Repositories.ViewModel
{
    public class BaseViewModel
    {
        public override string ToString()
        {
          return  JsonConvert.SerializeObject(this);
        }
    }
}