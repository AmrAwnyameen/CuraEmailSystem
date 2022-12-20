using AutoMapper;
using Core.Domain.Models.AppModels.Dashboard;
using Core.Domain.Models.ViewModels;
using Core.Domain.Models.ViewModels.DashBoard;

namespace Core.Domain.Mapping
{
    public class AutoMapperConfig
    {
        public static void RegiaterArigMapper()
        {

            Mapper.Initialize(cfg =>
            {
                #region MailInbox
                cfg.CreateMap<MailInboxViewModel, MailInboxViewModel>().ReverseMap();
                cfg.CreateMap<MailInbox, InboxCardViewModel>().ReverseMap();
                cfg.CreateMap<InboxCardViewModel, InboxCardViewModel>().ReverseMap();
                cfg.CreateMap<MailInboxViewModel, MailInbox>().ReverseMap();

                cfg.CreateMap<MailInbox, InboxCardViewModel>().ReverseMap().
                ForMember(d => d.FromUser, m => m.MapFrom(s =>
                s.user));

                Mapper.CreateMap<MailInbox, InboxCardViewModel>()
                .ForMember(x => x.user, opt => opt.MapFrom(model => model.FromUser));

                Mapper.CreateMap<InboxCardViewModel, MailInbox>()
            .ForMember(x => x.FromUser, opt => opt.MapFrom(model => model.user));


                #endregion

                #region UserMapping

            });
            #endregion

        }
    }
}