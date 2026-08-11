namespace HotelBooking.Application.Exceptions;

public class BookingNotFoundException : Exception
{
    public BookingNotFoundException(int bookingId)
        : base($"Booking {bookingId} was not found.")
    {
    }
}