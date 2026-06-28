using Fitness.Core.Abstractions;
using Fitness.Core.Models;

namespace Fitness.Application.Services
{
    public class MembershipsService : IMembershipsService
    {
        private readonly IMembershipsRepository _membershipsRepository;

        public MembershipsService(IMembershipsRepository membershinsRepository)
        {
            _membershipsRepository = membershinsRepository;
        }

        public async Task<List<Membership>> GetAllMemberships()
        {
            return await _membershipsRepository.GetMemberships();
        }

        public async Task<Guid> CreateMemberships(Membership membership)
        {
            return await _membershipsRepository.Create(membership);
        }

        public async Task<Guid> UpdateMemberships(Guid id, string name, string descriptions, decimal price)
        {
            return await _membershipsRepository.Update(id, name, descriptions, price);
        }

        public async Task<Guid?> DeleteMemberships(Guid id)
        {
            return await _membershipsRepository.Delete(id);
        }
    }
}
