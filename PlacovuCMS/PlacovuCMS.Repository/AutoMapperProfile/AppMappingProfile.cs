using AutoMapper;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;

namespace PlacovuCMS.Repository.AutoMapperProfile
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<BlogViewModel, Blog>();
            CreateMap<Blog, BlogViewModel>();

            CreateMap<BlogCategoryViewModel, BlogCategory>();
            CreateMap<BlogCategory, BlogCategoryViewModel>();

            CreateMap<MediaViewModel, Media>();
            CreateMap<Media, MediaViewModel>();

            CreateMap<MenuViewModel, Menu>();
            CreateMap<Menu, MenuViewModel>();

            CreateMap<PageViewModel, Page>();
            CreateMap<Page, PageViewModel>();

            CreateMap<EmailSmsConfigViewModel, EmailSmsConfig>();
            CreateMap<EmailSmsConfig, EmailSmsConfigViewModel>();

            CreateMap<ContactUsConfigViewModel, ContactUsConfig>();
            CreateMap<ContactUsConfig, ContactUsConfigViewModel>();

            CreateMap<EmailSmsHistoryViewModel, EmailSmsHistory>();
            CreateMap<EmailSmsHistory, EmailSmsHistoryViewModel>();

            CreateMap<SiteInfoViewModel, SiteInfo>();
            CreateMap<SiteInfo, SiteInfoViewModel>();

            CreateMap<SocialMediaConfigViewModel, SocialMediaConfig>();
            CreateMap<SocialMediaConfig, SocialMediaConfigViewModel>();

            CreateMap<NewsContentViewModel, News>();
            CreateMap<News, NewsContentViewModel>();

            CreateMap<EmploymentApplicationViewModel, EmploymentApplication>();
            CreateMap<EmploymentApplication, EmploymentApplicationViewModel>();
            
        }
    }
}
