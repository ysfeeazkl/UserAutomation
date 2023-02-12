using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Entities.Concrete;

namespace UserAutomation.Data.Concrete.Mappings
{
    public class WorkerMap : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(a => new { a.UserId, a.CompanyId});
            builder.HasOne<Company>(uo => uo.Company).WithMany(u => u.Workers).HasForeignKey(uo => uo.CompanyId);
            builder.HasOne<User>(a => a.User).WithMany(a => a.Workers).HasForeignKey(a => a.UserId);

            builder.ToTable("Workers");
        }
    }
}
