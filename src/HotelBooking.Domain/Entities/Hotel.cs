namespace HotelBooking.Domain.Entities;

public class Hotel
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Address { get; private set; }

    public string City { get; private set; }

    public string Country { get; private set; }

    public int StarRating { get; private set; }
    public ICollection<Room> Rooms { get; private set; } = new List<Room>();
    private Hotel()
    {
    }

    public Hotel(
     string name,
     string description,
     string address,
     string city,
     string country,
     int starRating)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Hotel name is required.");

        if (starRating < 1 || starRating > 5)
            throw new ArgumentException("Star rating must be between 1 and 5.");

        Name = name;
        Description = description;
        Address = address;
        City = city;
        Country = country;
        StarRating = starRating;
    }
}