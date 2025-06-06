using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class Category_optionRepository : GenericRepository<Category_option>, ICategory_optionRepository
{
    protected readonly FirstActivityDbContext _context;

    public Category_optionRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}