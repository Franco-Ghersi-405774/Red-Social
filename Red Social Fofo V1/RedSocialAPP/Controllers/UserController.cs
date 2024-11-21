using Microsoft.AspNetCore.Mvc;
using RedSocialAPP.Dtos;
using RedSocialAPP.Models;
using RedSocialAPP.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

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


        //[Route("/IniciarSesion")]
        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionDTO datos)
        {

            var usuario = await _repository.IniciarSesion(datos.Usuario, datos.Password);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
            }




            //var token = Token(response); // Método para generar el token

            //CREAR LAS CLAIMS / DATOS DEL USUARIO
            var claimss = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("IdUsuario",usuario.IdUsuario.ToString())

            };


            //Generar el TOKEN

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Eljefecrackdelcounterstrikeeselcazaputas42"));
            //firmar credenciales
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                
                
                issuer : "https://localhost:7214",
                audience : "http://127.0.0.1:5500",
                claims : claimss,
                expires: DateTime.Now.AddHours(1),
                signingCredentials : creds
                
            );




            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    usuario = new { Usuario = usuario }
                });
        }



        [Authorize]
        [HttpGet("DatosProtegidos")]
        public IActionResult DatosProtegidos()
        {
            var idUsuario = User.Claims.FirstOrDefault(c => c.Type == "IdUsuario")?.Value;
            return Ok(new { mensaje = "Acceso autorizado", idUsuario });
        }


        [Authorize]
        [HttpGet("GetPerfil")]
        public IActionResult GetPerfil()
        {
            var claims = User.Claims;

            var nombre = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var idUsuario = claims.FirstOrDefault(c => c.Type == "IdUsuario")?.Value;


            return Ok(new
            {
                Nombre = nombre,
                Email = email,
                IdUsuario = idUsuario
            });
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
