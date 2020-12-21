using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Services;
using SCIMServer.Extensions;
using SCIMServer.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Controllers
{
    [Route("/api/[controller]")]
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GroupResource>> GetAllAsync()
        {
            var groups = await _groupService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupResource>>(groups);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGroupResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Group = _mapper.Map<SaveGroupResource, Group>(resource);
            var result = await _groupService.SaveAsync(Group);

            if (!result.Success)
                return BadRequest(result.Message);

            var GroupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(GroupResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGroupResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var Group = _mapper.Map<SaveGroupResource, Group>(resource);
            var result = await _groupService.UpdateAsync(id, Group);

            if (!result.Success)
                return BadRequest(result.Message);

            var GroupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(GroupResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _groupService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var GroupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(GroupResource);
        }
    }
}
