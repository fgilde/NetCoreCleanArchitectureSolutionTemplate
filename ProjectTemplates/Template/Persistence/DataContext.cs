using $ext_safeprojectname$.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$
{
	internal class DataContext : DbContext
	{
        public DataContext(DbContextOptions options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
			=> modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}
