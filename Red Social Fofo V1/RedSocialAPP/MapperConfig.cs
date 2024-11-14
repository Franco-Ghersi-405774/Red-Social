using AutoMapper;
using RedSocialAPP.Dtos;
using RedSocialAPP.Models;

namespace RedSocialAPP
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<UsuarioDTO,Usuario>();

        }


    }
}
