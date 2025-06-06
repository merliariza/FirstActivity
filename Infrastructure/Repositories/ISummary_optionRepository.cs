using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Summary_optionRepository : Repository<Summary_option>, ISummary_optionRepository
{
    protected readonly FirstActivityDbContext _context;

    public Summary_optionRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}