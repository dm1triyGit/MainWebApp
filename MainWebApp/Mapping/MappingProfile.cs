using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using WebUI.Models.Account;

namespace WebUI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(x => x.Role.Name));

            CreateMap<UserDTO, User>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

            CreateMap<UserDTO, UserViewModel>();

            CreateMap<RegisterViewModel, UserDTO>();
        }
    }
}
