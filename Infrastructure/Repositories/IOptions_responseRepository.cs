using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Options_responseRepository : GenericRepository<Options_response>, IOptions_responseRepository
{
    protected readonly FirstActivityDbContext _context;

    public Options_responseRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}