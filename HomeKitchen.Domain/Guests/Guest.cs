using HomeKitchen.Domain.Common.Models;
using HomeKitchen.Domain.Guests.ValueObjects;

namespace HomeKitchen.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    public Guest(GuestId id) : base(id)
    {
    }

#pragma warning disable CS8618
    private Guest() { }
#pragma warning restore CS8618
}