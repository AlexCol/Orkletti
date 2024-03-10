using backendOrkletti.src.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace AUTENTICADOR.src.Model;

public class PostgreContext : DbContext {
	public PostgreContext() { }

	public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) {
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //!para permitir usar data 'local'
	}

	public DbSet<Profile> Profiles { get; set; }
	public DbSet<Community> Communities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Community>().Property("ProfileId").HasColumnName("cd_profile_id");
	}
}
