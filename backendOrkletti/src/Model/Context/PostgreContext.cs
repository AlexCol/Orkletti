using backendOrkletti.src.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace backendOrkletti.src.Model;

public class PostgreContext : DbContext {
	public PostgreContext() { }

	public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) {
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //!para permitir usar data 'local'
	}

	public DbSet<Profile> Profiles { get; set; }
	public DbSet<Community> Communities { get; set; }
	public DbSet<Topic> Topics { get; set; }
	public DbSet<Post> Posts { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Profile>().Property("Id").HasColumnName("cd_profile");
		modelBuilder.Entity<Profile>().HasMany<Post>().WithOne(p => p.CreatedBy).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Community>().Property("Id").HasColumnName("cd_community");
		modelBuilder.Entity<Community>().Property("CreatedById").HasColumnName("cd_created_by");
		modelBuilder.Entity<Community>().HasMany<Topic>().WithOne(t => t.Community).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Topic>().Property("Id").HasColumnName("cd_topic");
		modelBuilder.Entity<Topic>().Property("CommunityId").HasColumnName("cd_community");
		modelBuilder.Entity<Topic>().Property("CreatedById").HasColumnName("cd_created_by");
		modelBuilder.Entity<Topic>().HasMany<Post>().WithOne(p => p.Topic).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Post>().Property("Id").HasColumnName("cd_post");
		modelBuilder.Entity<Post>().Property("TopicId").HasColumnName("cd_topic");
		modelBuilder.Entity<Post>().Property("ProfileId").HasColumnName("cd_profile");
		modelBuilder.Entity<Post>().Property("CreatedById").HasColumnName("cd_created_by");
	}
}