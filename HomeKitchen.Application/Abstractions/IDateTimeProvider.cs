using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Application.Abstractions
{
    public interface IDateTimeProvider
    {
       public DateTime Now { get; }
    }
}
