﻿using HMSPlus.DataAccess.Models.Configurations;
using HMSPlus.DataAccess.Models.Hotels;
using HMSPlus.DataAccess.Models.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Providers
{
    public class HMSPlusDbContext : DbContext
    {
        public bool EnforceConsistency
        {
            get
            {
                var isEnabled = ConfigurationManager.AppSettings["EnforceDbConsistency"];

                return isEnabled != null && Convert.ToBoolean(isEnabled);
            }
        }

        public HMSPlusDbContext()
            : base("name=HMSPlusDbContext")
        {
        }

        public HMSPlusDbContext(string dbConnectionString)
            : base(dbConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.CommandTimeout = 300000;

            if (!EnforceConsistency)
            {
                Database.SetInitializer<HMSPlusDbContext>(null);
            }
        }


        public static HMSPlusDbContext Create()
        {
            return new HMSPlusDbContext();
        }

        public virtual DbSet<Models.Users.Action> Actions { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuAction> MenuActions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<HotelType> HotelTypes { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
           
        }
    }
}
