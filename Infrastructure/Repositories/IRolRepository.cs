using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities; 
using Infrastructure.Data;
namespace Infrastructure.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly FirstActivityDbContext _context;
        public RolRepository(FirstActivityDbContext context) : base(context) { }
    }
}