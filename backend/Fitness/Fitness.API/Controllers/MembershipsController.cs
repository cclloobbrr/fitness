using Fitness.API.Contracts;
using Fitness.Core.Abstractions;
using Fitness.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipsService _membershipsServices;

        public MembershipsController(IMembershipsService membershipsServices)
        {
            _membershipsServices = membershipsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<MembershipsResponse>>> GetAllMemberships()
        {
            var memberships = await _membershipsServices.GetAllMemberships();

            var response = memberships.Select(m => new MembershipsResponse(m.Id, m.Name, m.Description, m.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMembership([FromBody] MembershipsReqest reqest)
        {
            var (memberships, error) = Membership.Create(Guid.NewGuid(), reqest.Name, reqest.Descriptions, reqest.Price);

            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            var membershipsId = await _membershipsServices.CreateMemberships(memberships);

            return Ok(membershipsId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateMembership(Guid id, [FromBody] MembershipsReqest reqest)
        {
            var membershipsId = await _membershipsServices.UpdateMemberships(id, reqest.Name, reqest.Descriptions, reqest.Price);

            return Ok(membershipsId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid?>> DeleteMembership(Guid id)
        {
            var membershipsId = await _membershipsServices.DeleteMemberships(id);

            if(membershipsId == null) return NotFound(membershipsId);

            return Ok(membershipsId);
        }
    }
}
