using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class SellOrderItem : Abstract
    {
        public int Id { get; set; }
        public int SellOrderId { get; set; }

        public int ItemId { get; set; }

        public Decimal Price { get; set; }

        public virtual Item Items { set; get; }
        public virtual SellOrder SellOrders { set; get; }


    }
}