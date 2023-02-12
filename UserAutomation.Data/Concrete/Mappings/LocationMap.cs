using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Entities.Concrete;

namespace UserAutomation.Data.Concrete.Mappings
{
    public class LocationMap: IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.Country).HasMaxLength(20);
            builder.Property(u => u.Province).IsRequired();
            builder.Property(u => u.Province).HasMaxLength(30);

            builder.HasOne<Company>(a => a.Company).WithOne(a => a.CompanyLocation).HasForeignKey<Company>(c => c.CompanyLocationId);


            builder.ToTable("Locations");
        }
    }
}
