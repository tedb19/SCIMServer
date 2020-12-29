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
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<GroupResource> GetOneAsync(string id)
        {
            var group = await _groupService.FindByIdAsync(id);
            var resources = _mapper.Map<Group, GroupResource>(group);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGroupResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var group = _mapper.Map<SaveGroupResource, Group>(resource);
            var result = await _groupService.SaveAsync(group);

            if (!result.Success)
                return BadRequest(result.Message);

            var groupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(groupResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveGroupResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var group = _mapper.Map<SaveGroupResource, Group>(resource);
            var result = await _groupService.UpdateAsync(id, group);

            if (!result.Success)
                return BadRequest(result.Message);

            var groupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(groupResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _groupService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var groupResource = _mapper.Map<Group, GroupResource>(result.Group);
            return Ok(groupResource);
        }
    }
}
