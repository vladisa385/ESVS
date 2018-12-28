using AutoMapper;
using Entities;
using ViewModel.Roles;
using ViewModel.Users;
using ViewModel;

namespace ESVS
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Catalog, CatalogsResponse>();
            CreateMap<CreateCatalogsRequest, Catalog>();
            CreateMap<UpdateCatalogsRequest, Catalog>();


            CreateMap<User, UserResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.PathToAvatar, o => o.MapFrom(src => src.PathToAvatar))
                .ForMember(d => d.LevelId, o => o.MapFrom(src => src.LevelId))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))



                .ForAllOtherMembers(opts => opts.Ignore());
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
            CreateMap<Role, RoleResponse>();




        }
    }



}

