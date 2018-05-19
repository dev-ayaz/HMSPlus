using HMSPlus.DataAccess.Models.Hotels;
using HMSPlus.DataAccess.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Contracts
{
    public interface IUnitOfWork : IBaseUnitOfWork, IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<Menu> Menus { get; }
        IRepository<Models.Users.Action> Actions { get; }
        IRepository<MenuAction> MenuActions { get; }
        IRepository<RolePermission> RolePermissions { get; }

        IRepository<Hotel> Hotels { get; }
        IRepository<Floor> Floors { get; }

    }

}
