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


        //tamal
        [HttpGet("Iniciar Sesion")]
        public async Task<IActionResult> GetUserByUser(string user, string password)
        {

            var response = await _repository.FindUser(user,password);

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
            var response = await _repository.PostUser(usuario);

            if (response != null)
            {
                return Ok(response);
            }
            else { return NotFound(); }


        }

    }
}
