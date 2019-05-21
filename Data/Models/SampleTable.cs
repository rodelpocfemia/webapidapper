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
}
