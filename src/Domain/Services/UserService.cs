using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            // Domain business rules
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new DomainException("Username cannot be empty");

            if (user.Type == UserType.Internal && !user.StaffTypeId.HasValue)
                throw new DomainException("Internal users must have a staff type assigned");

            // Check if username already exists
            var existingUser = (await _unitOfWork.Users.FindAsync(u => u.Username == user.Username)).FirstOrDefault();
            if (existingUser != null)
                throw new DomainException($"Username '{user.Username}' already exists");

            return await _unitOfWork.Users.AddAsync(user);
        }

        public async Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId, Guid? departmentId = null)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);
            if (role == null)
                throw new DomainException($"Role with ID {roleId} not found");

            // Check if user already has this role
            var existingUserRole = new UserRole { UserId = userId, RoleId = roleId, DepartmentId = departmentId };
            
            // Business rule: Internal users can have department-specific roles
            if (user.Type == UserType.Internal && departmentId.HasValue)
            {
                var department = await _unitOfWork.Departments.GetByIdAsync(departmentId.Value);
                if (department == null)
                    throw new DomainException($"Department with ID {departmentId} not found");
            }

            // Add the role assignment (implementation would be in Infrastructure layer)
            // For now, return true as this is domain logic validation
            return true;
        }

        public async Task<bool> RemoveRoleFromUserAsync(Guid userId, Guid roleId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Business rule: Cannot remove the last role from a user
            var userRoles = await GetUserRolesAsync(userId);
            if (userRoles.Count() <= 1)
                throw new DomainException("Cannot remove the last role from a user");

            return true; // Implementation in Infrastructure layer
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // This would be implemented in Infrastructure layer
            // For now, return empty collection as this is domain logic
            return new List<Role>();
        }

        public async Task<bool> HasPermissionAsync(Guid userId, string permissionName)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            // Business rule: External users have limited permissions
            if (user.Type == UserType.External)
            {
                var allowedExternalPermissions = new[] { "view_own_profile", "edit_own_profile" };
                return allowedExternalPermissions.Contains(permissionName);
            }

            // For internal users, check their roles and permissions
            // Implementation would be in Infrastructure layer
            return true;
        }

        public async Task<bool> IsInternalUserAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return user.Type == UserType.Internal;
        }

        public async Task<bool> IsExternalUserAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return user.Type == UserType.External;
        }
    }
} 