using System;

namespace Shared
{
    public class Error : Exception
    {        
        public string Key { get;  set; }

        private bool v;

        public Error(string key, string errorMessage) : base(errorMessage)
        {
            Key = key;
        }

        public Error(string key, string errorMessage, bool v) : base(errorMessage)
        {
            Key = key;
            this.v = v;
        }
    }
}