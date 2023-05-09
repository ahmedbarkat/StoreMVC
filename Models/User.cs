using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Color { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? LastLogin { get; set; }

        public int? LastScopeId { get; set; }

        public virtual Foundation LastScope { set; get; }

    }
}