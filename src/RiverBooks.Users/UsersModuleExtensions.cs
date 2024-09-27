using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Serilog;

namespace RiverBooks.Users;

public static class UsersModuleExtensions
{
	public static IServiceCollection AddUserModuleServices(
		this IServiceCollection services,
		ConfigurationManager config,
		ILogger logger)
	{
		string? connectionString = config.GetConnectionString("UserConnectionString");
		services.AddDbContext<UsersDbContext>(config =>
				config.UseSqlServer(connectionString));

		services.AddIdentityCore<ApplicationUser>()
				.AddEntityFrameworkStores<UsersDbContext>();

		logger.Information("Serviços do Módulo {Module} foram registrados.", "Users");

		return services;
	}
}
public class UsersDbContext : IdentityDbContext
{
	public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
	{
	}

	public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.HasDefaultSchema("Users");

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.Properties<decimal>()
			.HavePrecision(18, 6);

	}

}
