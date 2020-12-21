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

        public GroupService(IGroupRepository GroupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = GroupRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<GroupResponse> DeleteAsync(int id)
        {
            var existingGroup = await _groupRepository.findByIdAsync(id);

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

        public async Task<GroupResponse> SaveAsync(Group Group)
        {
            try
            {
                await _groupRepository.AddAsync(Group);
                await _unitOfWork.CompleteAsync();

                return new GroupResponse(Group);
            }
            catch (Exception ex)
            {
                return new GroupResponse($"An error occured when saving the Group: {ex.Message}");
            }
        }

        public async Task<GroupResponse> UpdateAsync(int id, Group Group)
        {
            var existingGroup = await _groupRepository.findByIdAsync(id);

            if (existingGroup == null)
                return new GroupResponse("Group not found!");

            existingGroup.Name = Group.Name;

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
