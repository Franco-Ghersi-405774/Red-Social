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

        Task<Usuario> FindUser(string user_email, string password);

        Task<Usuario> PostUser(UsuarioDTO usuario);

    }
}
