using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Services;
using SCIMServer.Extensions;
using SCIMServer.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        public UsersController(IUserService UserService, IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var Users = await _UserService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(Users);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var User = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _UserService.SaveAsync(User);

            if (!result.Success)
                return BadRequest(result.Message);

            var UserResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(UserResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var User = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _UserService.UpdateAsync(id, User);

            if (!result.Success)
                return BadRequest(result.Message);

            var UserResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(UserResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _UserService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var UserResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(UserResource);
        }
    }
}
