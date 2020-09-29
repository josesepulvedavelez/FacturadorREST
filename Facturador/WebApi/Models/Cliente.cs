using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(15)]
        public string Cedula { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefonos { get; set; }

        public List<Factura> Facturas { get; set; }

    }
}
