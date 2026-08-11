namespace HotelBooking.Application.UseCases.Hotels.CreateHotel;

public class CreateHotelCommand
{
    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string Country { get; init; } = string.Empty;

    public int StarRating { get; init; }
}