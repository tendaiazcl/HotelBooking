namespace HotelBooking.Application.UseCases.Rooms.SearchAvailableRooms;

public class SearchAvailableRoomsQuery
{
    public int HotelId { get; init; }

    public DateTime CheckIn { get; init; }

    public DateTime CheckOut { get; init; }
}