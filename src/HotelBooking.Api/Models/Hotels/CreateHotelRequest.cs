namespace HotelBooking.Api.Models.Hotels;

public class CreateHotelRequest
{
    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string Country { get; init; } = string.Empty;

    public int StarRating { get; init; }
}