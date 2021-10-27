using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Typiqally.Persistence.Abstractions.Entities;

namespace Typiqally.Persistence.Abstractions
{
	public interface IApplicationDbContext
	{
		DbSet<WeatherForecastEntity> Forecasts { get; set; }
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}