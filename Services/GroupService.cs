using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Repositories;
using SCIMServer.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<Group> FindByIdAsync(string id)
        {
            return await _groupRepository.FindByIdAsync(id);
        }

        public async Task<GroupResponse> DeleteAsync(string id)
        {
            var existingGroup = await _groupRepository.FindByIdAsync(id);

            if (existingGroup == null)
            {
                return new GroupResponse("Group not found!");
            }

            try
            {
                _groupRepository.Remove(existingGroup);
                await _unitOfWork.CompleteAsync();
                return new GroupResponse(existingGroup);
            }
            catch (Exception ex)
            {
                return new GroupResponse($"An error occured when deleting the Group: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Group>> ListAsync()
        {
            return await _groupRepository.ListAsync();

        }

        public async Task<GroupResponse> SaveAsync(Group @group)
        {
            try
            {
                await _groupRepository.AddAsync(@group);
                await _unitOfWork.CompleteAsync();

                return new GroupResponse(@group);
            }
            catch (Exception ex)
            {
                return new GroupResponse($"An error occured when saving the Group: {ex.Message}");
            }
        }

        public async Task<GroupResponse> UpdateAsync(string id, Group @group)
        {
            var existingGroup = await _groupRepository.FindByIdAsync(id);

            if (existingGroup == null)
                return new GroupResponse("Group not found!");

            existingGroup.Name = @group.Name;

            try
            {
                _groupRepository.Update(existingGroup);
                await _unitOfWork.CompleteAsync();
                return new GroupResponse(existingGroup);
            }
            catch (Exception ex)
            {
                return new GroupResponse($"An error occured when updating the Group: {ex.Message}");
            }

        }
    }
}
