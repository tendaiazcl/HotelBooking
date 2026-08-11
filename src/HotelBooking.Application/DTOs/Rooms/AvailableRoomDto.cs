namespace HotelBooking.Application.DTOs.Rooms;

public class AvailableRoomDto
{
    public int RoomId { get; init; }

    public string RoomNumber { get; init; } = string.Empty;

    public string RoomType { get; init; } = string.Empty;

    public decimal PricePerNight { get; init; }
}