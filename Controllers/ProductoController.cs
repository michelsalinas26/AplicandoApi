using IntegrandoApi.Model;
using IntegrandoApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]    
        public void Agregar([FromBody] Producto produc)
        {
            ADO_Producto.AgregarProducto(produc);
        }

        [HttpPut]
        public void Modificar([FromBody] Producto produc)
        {
            ADO_Producto.ModificarProducto(produc);
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
    }
}
