using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class UserScopes
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FoundationId { get; set; }

        public bool Read { get; set; }
        public bool Edit { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
        public bool Print { get; set; }


        public virtual User Users { set; get; }


        public virtual Foundation Foundations { set; get; }

    }
}