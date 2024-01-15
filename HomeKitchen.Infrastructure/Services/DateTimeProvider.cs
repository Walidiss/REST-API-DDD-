using HomeKitchen.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Infrastructure.Services
{
    public  class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;

    }
}
