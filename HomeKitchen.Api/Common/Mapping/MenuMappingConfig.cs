//using HomeKitchen.Application.Menu.Commands;
//using HomeKitchen.Contracts.Menus;
//using HomeKitchen.Domain.Menus;
//using HomeKitchen.Domain.Menus.Entites;
//using Mapster;

//namespace HomeKitchen.Api.Common.Mapping
//{
//    public class MenuMappingConfig : IRegister
//    {
//        public void Register(TypeAdapterConfig config)
//        {
//            config.NewConfig <(CreateMenuRequest Request, Guid HostId), CreateMenuCommand>()
//                .Map(dest => dest.HostId, src => src.HostId)
//                .Map(dest => dest, src => src.Request);

//            config.NewConfig<Menu, MenuResponse>()
//                .Map(dest => dest.Id, src => src.Id.Value)
//                .Map(dest => dest.Name, src => src.Name)
//                .Map(dest => dest.AverageRating, src => src.AverageRating)
//                .Map(dest => dest.Sections, src => src.Sections)
//                .Map(dest => dest.HostId, src => src.HostId)
//                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
//                 .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

//            config.NewConfig<MenuSection, MenuSectionResponse>()
//                .Map(dest => dest.Id, src => src.Id.Value);

//            config.NewConfig<MenuItem, MenuItemResponse>()
//            .Map(dest => dest.Id, src => src.Id.Value);
//        }
//    }
//}


using HomeKitchen.Application.Menu.Commands;
using HomeKitchen.Contracts.Menus;
using HomeKitchen.Domain.Menus;
using Mapster;

using MenuSection = HomeKitchen.Domain.Menus.Entites.MenuSection;
using MenuItem = HomeKitchen.Domain.Menus.Entites.MenuItem;

namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, Guid HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
