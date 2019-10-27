using $ext_safeprojectname$.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$
{
	internal class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
			    => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}
