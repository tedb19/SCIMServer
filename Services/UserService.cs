using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Repositories;
using SCIMServer.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = UserRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.findByIdAsync(id);
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.findByIdAsync(id);

            if (existingUser == null)
            {
                return new UserResponse("User not found!");
            }

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured when deleting the User: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();

        }

        public async Task<UserResponse> SaveAsync(User User)
        {
            try
            {
                await _userRepository.AddAsync(User);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(User);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured when saving the User: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User User)
        {
            var existingUser = await _userRepository.findByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found!");

            existingUser.Name = User.Name;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured when updating the User: {ex.Message}");
            }

        }
    }
}
