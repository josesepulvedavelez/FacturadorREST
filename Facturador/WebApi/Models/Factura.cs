using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [StringLength(5)]
        public string Numero { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "Decimal(18, 2)")]
        public decimal Total { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
