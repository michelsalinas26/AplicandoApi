using IntegrandoApi.Model;
using IntegrandoApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void Insertar([FromBody] Venta vent)
        {
            ADO_Venta.AgregarVenta(vent);
        }
    }
}
