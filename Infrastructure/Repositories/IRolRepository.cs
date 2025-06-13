using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RolRepository : GenericRepository<role>, IRolRepository
    {
        private readonly FirstActivityDbContext _context;

        public RolRepository(FirstActivityDbContext context) : base(context)
        {
            _context = context;
        }

        public void Attach(role role)
        {
            _context.roles.Attach(role);
        }
    }
}
