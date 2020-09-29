using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Detalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "Decimal(18, 2)")]
        public decimal Precio { get; set; }

        [Column(TypeName = "Decimal(18, 2)")]
        public decimal Subtotal { get; set; }
        
        [ForeignKey("Factura")]
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
