using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers
{
    [HtmlTargetElement("GetIcons")]
	public class SocialMediaIconTagHelper : TagHelper
	{
        public int AppUserId { get; set; }
        private readonly IAppUserService _appUserService;
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IMapper _mapper;

        public SocialMediaIconTagHelper(IAppUserService appUserService, ISocialMediaIconService socialMediaIconService, IMapper mapper)
        {
            _appUserService = appUserService;
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var icons = _socialMediaIconService.GetByUserId(AppUserId);
            string data = "<div class='social-icons'>";
            foreach (var item in icons)
            {
                data += $@"<a target='_blank' class='social-icon' href='{item.Link}'><i class='{item.Icon}'></i></a>";
            }

            data += "</div>";
            output.Content.SetHtmlContent(data);
        }
    }
}
