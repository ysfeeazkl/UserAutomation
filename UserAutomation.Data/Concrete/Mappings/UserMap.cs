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
   
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50);

            builder.HasOne<Location>(a => a.HomeLocation).WithOne(a => a.User).HasForeignKey<Location>(c => c.UserId);


            builder.ToTable("Users");
        }
    }
}
