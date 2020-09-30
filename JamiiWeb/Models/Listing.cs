using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JamiiWeb.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime ListDate { get; set; }
        // Where to host images with C# API (CloudFlare...?)
        public List<Uri> Images { get; set; }
    }

    public class Ad : Listing
    {
        public string Description { get; set; }
        public int MyProperty { get; set; }
        // should I use float instead?
        public double Price { get; set; }
        public int ExchangeId { get; set; }
        public string Exchange { get; set; } // Trade, Sell, Free
    }

    public class Post : Listing
    {
        public string Body { get; set; }
        public string MyProperty { get; set; }
    }
}
