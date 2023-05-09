using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class Abstract
    {
        public int? CreatedById { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User CreatedBy { set; get; }

        public virtual User UpdatedBy { set; get; }
    }

}
