using Fitness.Core.Models;

namespace Fitness.Core.Abstractions
{
    public interface IMembershipsRepository
    {
        Task<Guid> Create(Membership membership);
        Task<Guid?> Delete(Guid id);
        Task<List<Membership>> GetMemberships();
        Task<Guid> Update(Guid id, string name, string description, decimal price);
    }
}