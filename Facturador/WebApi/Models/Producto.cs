using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }
                
        public int Stock { get; set; }

        public List<Detalle> Detalles { get; set; }
    }
}
