using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<StaffType> StaffTypes { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Office> Offices { get; }
        IRepository<Location> Locations { get; }
        IRepository<Department> Departments { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<AuditTrail> AuditTrails { get; }
        IRepository<Session> Sessions { get; }
        
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 