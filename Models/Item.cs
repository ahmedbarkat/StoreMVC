using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class Item : Abstract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? InitialPrice { get; set; }
        public string Notes { get; set; }

    }
}