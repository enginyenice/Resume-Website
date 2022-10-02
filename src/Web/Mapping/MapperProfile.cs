using AutoMapper;
using DTO.DTOs.AppUserDtos;
using DTO.DTOs.CertificationDtos;
using DTO.DTOs.EducationDtos;
using DTO.DTOs.ExperienceDtos;
using DTO.DTOs.InterestDtos;
using DTO.DTOs.LogDtos;
using DTO.DTOs.SkillDtos;
using DTO.DTOs.SocialMediaIconDtos;
using Entities.Concrete;

namespace Web.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<Certification, CertificationListDto>().ReverseMap();
            CreateMap<Certification, CertificationAddDto>().ReverseMap();
            CreateMap<Certification, CertificationUpdateDto>().ReverseMap();

            CreateMap<Education, EducationListDto>().ReverseMap();
            CreateMap<Education, EducationAddDto>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();
            

            CreateMap<Experience, ExperienceListDto>().ReverseMap();
            CreateMap<Experience, ExperienceAddDto>().ReverseMap();
            CreateMap<Experience, ExperienceUpdateDto>().ReverseMap();

            CreateMap<Interest, InterestListDto>().ReverseMap();
            CreateMap<Interest, InterestAddDto>().ReverseMap();
            CreateMap<Interest, InterestUpdateDto>().ReverseMap();

            CreateMap<Skill, SkillListDto>().ReverseMap();
            CreateMap<Skill, SkillAddDto>().ReverseMap();
            CreateMap<Skill, SkillUpdateDto>().ReverseMap();

            CreateMap<SocialMediaIcon, SocialMediaIconListDto>().ReverseMap();
            CreateMap<SocialMediaIcon, SocialMediaIconAddDto>().ReverseMap();
            CreateMap<SocialMediaIcon, SocialMediaIconUpdateDto>().ReverseMap();

            CreateMap<Log, LogListDto>().ReverseMap();
        }
    }
}
