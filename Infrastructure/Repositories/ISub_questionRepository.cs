using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Sub_questionRepository : GenericRepository<Sub_question>, ISub_questionRepository
{
    protected readonly FirstActivityDbContext _context;

    public Sub_questionRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}