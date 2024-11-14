using RedSocialAPP.Dtos;
using RedSocialAPP.Models;

namespace RedSocialAPP.Repository
{
    public interface IUsuarioRepository
    {

        Task<List<Usuario>> GetAllUsuarios();

        Task<Usuario> FindById(int id);

        Task<Usuario> FindByName(string nombre);

        Task<Usuario> FindByEmail(string email);

        Task<Usuario> ExisteMailUsuario(string email, string usuario);

        Task<Usuario> IniciarSesion(string user_email, string password);

        Task<Usuario> PostUser(UsuarioDTO usuario);

    }
}
