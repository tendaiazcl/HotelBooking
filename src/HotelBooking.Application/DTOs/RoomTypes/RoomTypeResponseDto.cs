namespace HotelBooking.Application.DTOs.RoomTypes;

public class RoomTypeResponseDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public int Capacity { get; init; }

    public decimal BasePrice { get; init; }
}