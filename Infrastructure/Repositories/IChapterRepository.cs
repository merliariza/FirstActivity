using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
{
    protected readonly FirstActivityDbContext _context;

    public ChapterRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}