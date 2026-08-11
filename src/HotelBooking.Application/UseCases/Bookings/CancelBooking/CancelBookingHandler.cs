using HotelBooking.Application.Interfaces;

namespace HotelBooking.Application.UseCases.Bookings.CancelBooking;


public class CancelBookingHandler
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelBookingHandler(
        IBookingRepository bookingRepository,
        IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CancelBookingCommand command)
    {
        var booking =
            await _bookingRepository.GetByIdAsync(command.BookingId);

        if (booking is null)
            throw new InvalidOperationException(
                "Booking not found.");

        booking.Cancel();

        await _unitOfWork.SaveChangesAsync();
    }
}