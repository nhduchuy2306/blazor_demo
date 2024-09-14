using Microsoft.EntityFrameworkCore.Storage;
using ServerLibrary.Models;
using System.Data;

namespace ServerLibrary.Repositories;

public class MyTransaction
{
    private readonly ManagementdbContext _context;

    public MyTransaction(ManagementdbContext context)
    {
        _context = context;
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}
