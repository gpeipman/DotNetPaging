using AutoMapper;
using DotNetPaging.AspNetCore.Models;
using DotNetPaging.EFCore;

namespace DotNetPaging.AspNetCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PressRelease, PressReleaseListItem>();
        }
    }
}
