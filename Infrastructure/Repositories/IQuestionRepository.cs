using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    protected readonly FirstActivityDbContext _context;

    public QuestionRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}