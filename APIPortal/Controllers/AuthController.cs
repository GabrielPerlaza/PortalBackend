using Capa_DTO.AuthDTO;
using Capa_DTO.UsuarioDTO;
using Capa_Negocio.Servicios.Contrato;
using Capa_Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        [Route("Usuario")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<UsuarioReadDTO>();
            try
            {
                rsp.Status = true;
                rsp.value = await _authService.Obtener(id);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var rsp = new Response<SesionDTO>();
            try
            {
                rsp.Status = true;
                rsp.value = await _authService.ValidarCredenciales(login.Correo, login.Clave);

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
