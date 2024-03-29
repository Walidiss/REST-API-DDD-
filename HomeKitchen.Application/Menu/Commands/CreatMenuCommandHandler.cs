using ErrorOr;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Contracts.Authentication;
using HomeKitchen.Contracts.Menus;
using MediatR;
using HomeKitchen.Domain.Menus;
using HomeKitchen.Domain.Menus.Entites;
using HomeKitchen.Domain.Hosts.ValueObjects;


namespace HomeKitchen.Application.Menu.Commands
{
    public class CreatMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.Menus.Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreatMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Domain.Menus.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // create Menu
            var menu = Domain.Menus.Menu.Create(
                hostId: HostId.Create(request.HostId),
                request.Name,
                request.Description,
                sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                    name: sections.Name,
                    description: sections.Description,
                    items: sections.Items.ConvertAll(item => MenuItem.Create(
                        name: item.Name,
                        description: item.Description
                        )))));

            //persistance
            _menuRepository.Add(menu);

            // get menu 
            return menu;
        }
    }
}
