using System;
using System.Collections.Generic;

namespace webapidapper.Data.Models
{
    public class SampleTable
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class SampleRequest
    {
        public SampleTable Item { get; set; }
    }

    public class SampleImage
    {
        public string ImageData { get; set; }
        public string ImageFileName { get; set; }
    }

    public class ImageRequest
    {
        public SampleImage Image { get; set; }
    }
}
