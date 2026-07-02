using AutoMapper;
using Capa_DTO.ArticuloDTO;
using Capa_DTO.AuthDTO;
using Capa_DTO.UsuarioDTO;
using Modelos;

namespace Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Articulo

            CreateMap<ArticuloPostedDTO, Articulo>()
            .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<ArticuloUpdateDTO, Articulo>().ReverseMap();

            CreateMap<Articulo, ArticuloReadDTO>().ReverseMap();

            CreateMap<Articulo, ArticuloPreviewDTO>().ReverseMap();

            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioReadDTO>().ReverseMap();
            CreateMap<Usuario, SesionDTO>().ReverseMap();
            #endregion


        }


    }
}
