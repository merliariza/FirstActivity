using System.Linq;
using Application.Interface;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
{
    protected readonly FirstActivityDbContext _context;

    public SurveyRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}
