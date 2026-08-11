namespace HotelBooking.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();
}