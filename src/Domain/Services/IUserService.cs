using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId, Guid? departmentId = null);
        Task<bool> RemoveRoleFromUserAsync(Guid userId, Guid roleId);
        Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId);
        Task<bool> HasPermissionAsync(Guid userId, string permissionName);
        Task<bool> IsInternalUserAsync(Guid userId);
        Task<bool> IsExternalUserAsync(Guid userId);
    }
} 