using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedSocialAPP.Dtos;
using RedSocialAPP.Models;

namespace RedSocialAPP.Repository
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly RedSocialFofoContext _context;
        private readonly IMapper _mapper;



        public UsuarioRepository(RedSocialFofoContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Usuario> FindByEmail(string email)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);


            if (result == null) {
            
                return null;
            
            } 
            return result;
        }

        public async Task<Usuario> FindById(int id)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(x=> x.IdUsuario == id);

            if (result != null) {
            
                return result;
            }

            return null;
        }

        public async Task<Usuario> FindByName(string nombre)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nombre == nombre);

            if (result == null)
            {
                return null;
            }

            return result;

        }


        public async Task<List<Usuario>> GetAllUsuarios()
        {
            var result = await _context.Usuarios.ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }

            else
            {
                return result;
            }
        }
       
        
        public async Task<Usuario> FindUser(string user_email, string password)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == user_email && x.Contraseña == password || x.Usuario1 == user_email && x.Contraseña == password);

            if (result == null) 
            {
                return null;
            }

            else { return result; }
        }

        public async Task<Usuario> PostUser(UsuarioDTO usuariodto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuariodto);

            usuario.FechaRegistro = DateTime.Now;

            var result = await _context.AddAsync(usuario);
                         await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
