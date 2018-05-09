using HMSPlus.DataAccess.Contracts;
using HMSPlus.DataAccess.Models.Users;
using HMSPlus.DataAccess.Providers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Providers
{

    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {

        public UnitOfWork(IRepositoryProvider repositoryProvider) : this(repositoryProvider, "HMSPlusDbContext") { }

        public UnitOfWork(IRepositoryProvider repositoryProvider, string dbConnectionString) : base(repositoryProvider, dbConnectionString)
        {
        }

        protected override void CreateDbContext(string dbConnectionString)
        {
            DbContext = string.IsNullOrEmpty(dbConnectionString) ? new HMSPlusDbContext() : new HMSPlusDbContext(dbConnectionString);
        }

        public IRepository<User> Users => GetStandardRepository<User>();
        public IRepository<Role> Roles => GetStandardRepository<Role>();
        public IRepository<UserRole> UserRoles => GetStandardRepository<UserRole>();
        public IRepository<Menu> Menus => GetStandardRepository<Menu>();
        public IRepository<Models.Users.Action> Actions => GetStandardRepository<Models.Users.Action>();
        public IRepository<MenuAction> MenuActions => GetStandardRepository<MenuAction>();
        public IRepository<RolePermission> RolePermissions => GetStandardRepository<RolePermission>();

    }

}
