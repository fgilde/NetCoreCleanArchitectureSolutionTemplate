using $ext_safeprojectname$.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace $safeprojectname$.Configurations
{
    class MyEntityConfiguration : IEntityTypeConfiguration<MyEntity>
    {
        public void Configure(EntityTypeBuilder<MyEntity> builder)
        {
            builder.ToTable("MyEntity");
            builder.HasKey(e => e.Id);
        }
        
    }
}