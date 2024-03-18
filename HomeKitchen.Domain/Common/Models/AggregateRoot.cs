using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitchen.Domain.Common.Models
{
    public  abstract class AggregateRoot <TId, TIdType> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id) 
        {
        }
    }
}
