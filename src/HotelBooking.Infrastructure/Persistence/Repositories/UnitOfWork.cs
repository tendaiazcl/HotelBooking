using HotelBooking.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelBooking.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelBookingDbContext _context;

    private IDbContextTransaction? _transaction;

    public UnitOfWork(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction =
            await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is null)
            return;

        await _context.SaveChangesAsync();

        await _transaction.CommitAsync();

        await _transaction.DisposeAsync();

        _transaction = null;
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is null)
            return;

        await _transaction.RollbackAsync();

        await _transaction.DisposeAsync();

        _transaction = null;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}