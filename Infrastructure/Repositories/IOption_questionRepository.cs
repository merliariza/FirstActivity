using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Option_questionRepository : GenericRepository<Option_question>, IOption_questionRepository
{
    protected readonly FirstActivityDbContext _context;

    public Option_questionRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}