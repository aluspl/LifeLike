using System.Collections.Generic;

namespace Shared
{
    public class Envelope<T>
    {
        private EmptyData emptyData;

        public Envelope(EmptyData emptyData)
        {
            this.emptyData = emptyData;
        }

        public ICollection<Error> Errors { get; set; }
    }
}