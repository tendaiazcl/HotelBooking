namespace HotelBooking.Domain.Entities;

public class RoomType
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int Capacity { get; private set; }

    public decimal BasePrice { get; private set; }

    private RoomType()
    {
    }

    public RoomType(
        string name,
        string description,
        int capacity,
        decimal basePrice)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Room type name is required.");

        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        if (basePrice < 0)
            throw new ArgumentException("Base price cannot be negative.");

        Name = name;
        Description = description;
        Capacity = capacity;
        BasePrice = basePrice;
    }
}