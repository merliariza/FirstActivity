using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member> GetByUsernameAsync(string username);
    }
}