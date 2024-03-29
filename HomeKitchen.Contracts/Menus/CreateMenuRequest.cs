using HomeKitchen.Domain.Menus.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeKitchen.Contracts.Menus
{
    public record  CreateMenuRequest(
         string Name,
         string Description,
         List<CreatMenuSection> Sections
        );

    public record CreatMenuSection(
      string Name,
      string Description,
      List<CreateItem> Items

      );
    public record CreateItem(
           string Name,
        string Description
        );

}
