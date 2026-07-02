using Capa_DTO.ArticuloDTO;
using Capa_Negocio.Servicios;
using Capa_Negocio.Servicios.Contrato;
using Capa_Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace APIPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;
        private readonly CloudinaryService _cloudinaryService;

        public ArticuloController(IArticuloService articuloService, CloudinaryService cloudinaryService)
        {
            _articuloService = articuloService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ArticuloPreviewDTO>>();
            try
            {
                rsp.Status = true;
                rsp.value = await _articuloService.Lista();

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var rsp = new Response<ArticuloReadDTO>();
            try {
                rsp.Status = true;
                rsp.value = await _articuloService.Obtener(id);
            }
            catch(Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }
        

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ArticuloPostedDTO producto)
        {
            var rsp = new Response<ArticuloPostedDTO>();
            try
            {
                rsp.Status = true;
                rsp.value = await _articuloService.Crear(producto);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]

        public async Task<IActionResult> Editar([FromBody] ArticuloUpdateDTO articulo)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.value = await _articuloService.Editar(articulo);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:Guid}")]

        public async Task<IActionResult> Eliminar(Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.value = await _articuloService.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("SubirImagen")]
        public async Task<IActionResult> SubirImagen(IFormFile archivo)
        {
            var rsp = new Response<string>();
            try
            {
                rsp.Status = true;
                rsp.value = await _cloudinaryService.SubirImagen(archivo);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }



    }
}
