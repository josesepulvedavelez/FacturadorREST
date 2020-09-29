using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Request;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturadorContext context;

        public FacturaController(FacturadorContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFactura()
        { 
            return await context.Factura.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await context.Factura.FindAsync(id);

            if (factura == null)
            {
                return BadRequest();
            }

            return factura;
        }
        
        [HttpPost]
        public IActionResult PostFactura([FromBody] FacturaRequest facturaRequest)
        {             
            using (var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    Factura factura = new Factura();
                    factura.Numero = facturaRequest.Numero;
                    factura.Fecha = facturaRequest.Fecha;
                    factura.Total = facturaRequest.DetalleRequests.Sum(s => s.Cantidad * s.Precio);
                    factura.ClienteId = facturaRequest.ClienteId;
                    context.Factura.Add(factura);
                    context.SaveChanges();

                    foreach (var item in facturaRequest.DetalleRequests)
                    {
                        Detalle detalle = new Detalle();
                        detalle.Cantidad = item.Cantidad;
                        detalle.Precio = item.Precio;
                        detalle.Subtotal = item.Cantidad * item.Precio;
                        detalle.FacturaId = factura.FacturaId;
                        detalle.ProductoId = item.ProductoId;
                        context.Detalle.Add(detalle);
                    }
                    context.SaveChanges();

                    context.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.Database.RollbackTransaction();
                    string mensaje = ex.Message;
                }
            }
            
            return Ok(new { result = true });
        }
    }
}
