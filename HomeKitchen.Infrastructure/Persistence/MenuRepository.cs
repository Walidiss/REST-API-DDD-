using HomeKitchen.Application.Persistence;
using HomeKitchen.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {

        private static readonly List<Menu> _menus = new() ;
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
