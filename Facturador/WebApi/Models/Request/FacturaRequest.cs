using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Request
{
    public class FacturaRequest
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

        public List<DetalleRequest> DetalleRequests { get; set; }
    }

    public class DetalleRequest
    { 
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int ProductoId { get; set; }
    }
}
