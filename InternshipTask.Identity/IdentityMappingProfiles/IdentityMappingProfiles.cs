using AutoMapper;
using InternshipTask.Identity.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace InternshipTask.Identity.IdentityMappingProfiles
{
    internal class IdentityMappingProfiles : Profile
    {
        public IdentityMappingProfiles() {
            CreateMap<User,IdentityUser>();
        }
    }
}
