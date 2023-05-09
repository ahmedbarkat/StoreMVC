using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Safoa.Models
{
    public class Engine : Abstract
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "رقم المحرك مطلوب")]
        public string EngineNum { get; set; }
        [Required(ErrorMessage = "رقم الشهاده")]
        public string CertificateNum { get; set; }
        public string VoucherNum { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

    }
}