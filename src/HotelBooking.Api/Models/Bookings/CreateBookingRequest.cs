namespace HotelBooking.Api.Contracts.Bookings;

public class CreateBookingRequest
{
    public int CustomerId { get; init; }

    public int RoomId { get; init; }

    public DateTime CheckIn { get; init; }

    public DateTime CheckOut { get; init; }
}