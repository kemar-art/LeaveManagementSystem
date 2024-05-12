using LeaveManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Identity.DbContext
{
    public class LeaveIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeaveIdentityDbContext(DbContextOptions<LeaveIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LeaveIdentityDbContext).Assembly);
        }
    }
}
