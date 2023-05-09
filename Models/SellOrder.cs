using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class SellOrder : Abstract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal TotalPrice { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }

        public string Notes { get; set; }




    }
}