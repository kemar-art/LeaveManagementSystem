using LeaveManagementSytem.Domian;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.SeedDataConfiguration
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<Leavetype>
    {
        public void Configure(EntityTypeBuilder<Leavetype> builder)
        {
            builder.HasData(
                new Leavetype
                {
                    Id = 1,
                    Name = "Vacation",
                    DefaultDays = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });
        }
    }
}
