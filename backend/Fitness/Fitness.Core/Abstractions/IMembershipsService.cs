using Fitness.Core.Models;

namespace Fitness.Core.Abstractions
{
    public interface IMembershipsService
    {
        Task<Guid> CreateMemberships(Membership membership);
        Task<Guid> DeleteMemberships(Guid id);
        Task<List<Membership>> GetAllMemberships();
        Task<Guid?> UpdateMemberships(Guid id, string name, string descriptions, decimal price);
    }
}