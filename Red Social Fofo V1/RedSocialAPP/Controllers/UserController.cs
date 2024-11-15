using Microsoft.AspNetCore.Mvc;
using RedSocialAPP.Dtos;
using RedSocialAPP.Models;
using RedSocialAPP.Repository;

namespace RedSocialAPP.Controllers
{
    public class UserController : Controller
    {

        private readonly IUsuarioRepository _repository;

        public UserController(IUsuarioRepository repo) {
           
          _repository = repo;
        
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetallUsers()
        {
            var response = await _repository.GetAllUsuarios();

            if (response == null)
            {
                return NotFound();
            }
            else 
            {
               return Ok(response);
            }

        }

        //tamal
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetUserByID(int id) {
        
            var response = await _repository.FindById(id);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {

            var response = await _repository.FindByEmail(email);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetUserByName(string name)
        {

            var response = await _repository.FindByName(name);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [Route("/IniciarSesion")]
        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionDTO datos)
        {

            var response = await _repository.IniciarSesion(datos.Usuario, datos.Password);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                //var token = Token(response); // Método para generar el token
                return Ok(new { Usuario = response});
            }
        }

        [HttpPost("CrearUsuario")]

        public async Task<IActionResult> PostUser([FromBody]UsuarioDTO usuario)
        {
            var usuarioExiste = await _repository.ExisteMailUsuario(usuario.Email,usuario.Usuario1);
            Usuario user = null;

            if (usuarioExiste == null)
            {
                user = await _repository.PostUser(usuario);

                if (user != null)
                {
                    return Ok(user);
                }
                else {
                    return NotFound();
                }

            }
           
           return Conflict("El usuario o el correo ya están registrados.");

        }


        ////controller para consultar si ya existe el mail o el usuario, ya que no se puede crear 2 cuentas con el mismo mail o nombre de usuario anashei
        //[HttpPost("ConsultarMailyUsuario")]
        ////creamos que sea TASK por que es un asyncono que puede devuelve un valor ponele
        //public async Task<Usuario> ConsultarMailUsuario(string mail,string usuario) 
        //{ 

        //    var user = await _repository.ExisteMailUsuario(mail,usuario);
            

        //    if(user == null)
        //    {
        //        return BadRequest();
        //    }

        //}

    }
}
