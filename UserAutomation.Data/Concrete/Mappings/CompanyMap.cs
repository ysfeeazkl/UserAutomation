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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(20);
            builder.Property(u => u.Sector).IsRequired();
            builder.Property(u => u.Sector).HasMaxLength(30);

            //builder.HasOne<Location>(a => a.CompanyLocation).WithOne(a => a.Company).HasForeignKey<Location>(c => c.CompanyId);

            builder.ToTable("Companies");
        }
    }
}
