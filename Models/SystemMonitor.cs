using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class SystemMonitor
    {
        // Primitive properties
        public int Id { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime Time { set; get; }
        public string Controller { set; get; }
        public string Action { set; get; }
        public string Paramters { set; get; }
        public string Browser { set; get; }
        public string Ip { set; get; }
        public int? UserId { set; get; }
        public string Notes { set; get; }

        // Navigation properties
        public virtual User User { set; get; }
    }
}