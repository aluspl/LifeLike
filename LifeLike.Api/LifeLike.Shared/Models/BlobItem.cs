using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifeLike.Shared.Models
{
    public class BlobItem
    {
        public string Container { get; set; }
        public Uri Uri { get; set; }
        public Uri StorageUri { get; set; }
        public Stream Stream { get; set; }
        public string Name { get; set; }
    }
}
