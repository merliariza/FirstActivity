using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Categories_catalogRepository : GenericRepository<Categories_catalog>, ICategories_catalogRepository
{
    protected readonly FirstActivityDbContext _context;

    public Categories_catalogRepository(FirstActivityDbContext context) : base(context)
    {
        _context = context;
    }
}
