using Microsoft.EntityFrameworkCore;
using Typiqally.Persistence.Abstractions;
using Typiqally.Persistence.Abstractions.Entities;

namespace Typiqally.Persistence
{
	public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<WeatherForecastEntity> Forecasts { get; set; }
	}
}