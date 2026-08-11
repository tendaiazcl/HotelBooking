using HotelBooking.Application.Interfaces;

namespace HotelBooking.Application.UseCases.Bookings.CancelBooking;

public class CancelBookingHandler
{
    private readonly IBookingRepository _bookingRepository;

    public CancelBookingHandler(
        IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task Handle(CancelBookingCommand command)
    {
        var booking =
            await _bookingRepository.GetByIdAsync(command.BookingId);

        if (booking is null)
            throw new InvalidOperationException(
                "Booking not found.");

        booking.Cancel();
    }
}