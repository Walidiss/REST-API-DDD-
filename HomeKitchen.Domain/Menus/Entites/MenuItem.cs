using HomeKitchen.Domain.Common.Models;
using HomeKitchen.Domain.Menus.ValueObjects;
using System.Text.Json.Serialization;

namespace HomeKitchen.Domain.Menus.Entites;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

#pragma warning disable CS8618
    private MenuItem() { }
#pragma warning restore CS8618
}