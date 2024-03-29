using HomeKitchen.Domain.Bills.ValueObjects;
using HomeKitchen.Domain.Common.Models;
using HomeKitchen.Domain.Dinners.ValueObjects;
using HomeKitchen.Domain.Guests.ValueObjects;
using HomeKitchen.Domain.Hosts.ValueObjects;

namespace HomeKitchen.Domain.Bills;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; } = null;
    public GuestId GuestId { get; } = null;
    public HostId HostId { get; } = null;
    public Price Price { get; } = null;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId id,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new(
            BillId.CreateUnique(),
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    private Bill() { }
}