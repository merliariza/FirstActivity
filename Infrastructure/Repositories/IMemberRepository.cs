using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities; 
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly FirstActivityDbContext _context;
        public MemberRepository(FirstActivityDbContext context) : base(context) { }
        public async Task<Member> GetByUsernameAsync(string username)
        {
            return await _context.Members
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}