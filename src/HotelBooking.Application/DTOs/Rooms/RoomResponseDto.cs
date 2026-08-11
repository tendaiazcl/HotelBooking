namespace HotelBooking.Application.DTOs.Rooms;

public class RoomResponseDto
{
    public int Id { get; init; }

    public string RoomNumber { get; init; } = string.Empty;

    public int HotelId { get; init; }

    public int RoomTypeId { get; init; }
}