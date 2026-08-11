using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.UseCases.Bookings.CreateBooking;

public class CreateBookingHandler
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingHandler(
        ICustomerRepository customerRepository,
        IRoomRepository roomRepository,
        IBookingRepository bookingRepository,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Booking> Handle(CreateBookingCommand command)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var customer =
                await _customerRepository.GetByIdAsync(command.CustomerId);

            if (customer is null)
                throw new InvalidOperationException("Customer not found.");

            var room =
                await _roomRepository.GetByIdAsync(command.RoomId);

            if (room is null)
                throw new InvalidOperationException("Room not found.");

            var hasOverlap =
                await _bookingRepository.HasOverlappingBookingAsync(
                    command.RoomId,
                    command.CheckIn,
                    command.CheckOut);

            if (hasOverlap)
                throw new InvalidOperationException(
                    "Room is not available for the selected dates.");

    var booking = new Booking(
        command.CustomerId,
        command.RoomId,
        command.CheckIn,
        command.CheckOut,
        room.RoomType.BasePrice);

            await _bookingRepository.AddAsync(booking);

            await _unitOfWork.CommitTransactionAsync();

            return booking;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();

            throw;
        }
    }
}