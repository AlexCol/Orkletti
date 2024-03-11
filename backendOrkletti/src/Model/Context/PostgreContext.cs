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
	public DbSet<LikeOrDislikeRegister> LikeOrDislikeRegisters { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Profile>().Property("Id").HasColumnName("cd_profile");
		modelBuilder.Entity<Profile>().HasMany<Post>().WithOne(p => p.CreatedBy).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Community>().Property("Id").HasColumnName("cd_community");
		modelBuilder.Entity<Community>().Property("CreatedById").HasColumnName("cd_created_by");
		modelBuilder.Entity<Community>().HasMany<Topic>().WithOne(t => t.Community).OnDelete(DeleteBehavior.Cascade);
		modelBuilder.Entity<Community>().HasMany<ComunityMembership>().WithOne(t => t.Community).OnDelete(DeleteBehavior.Cascade);
		modelBuilder.Entity<Community>().HasMany<CommunityRequestMembership>().WithOne(t => t.Community).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Topic>().Property("Id").HasColumnName("cd_topic");
		modelBuilder.Entity<Topic>().Property("CommunityId").HasColumnName("cd_community");
		modelBuilder.Entity<Topic>().Property("CreatedById").HasColumnName("cd_created_by");
		modelBuilder.Entity<Topic>().HasMany<Post>().WithOne(p => p.Topic).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Post>().Property("Id").HasColumnName("cd_post");
		modelBuilder.Entity<Post>().Property("TopicId").HasColumnName("cd_topic");
		modelBuilder.Entity<Post>().Property("ProfileId").HasColumnName("cd_profile");
		modelBuilder.Entity<Post>().Property("CreatedById").HasColumnName("cd_created_by");
		modelBuilder.Entity<Post>().HasMany<LikeOrDislikeRegister>().WithOne(l => l.Post).OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<LikeOrDislikeRegister>().Property("Id").HasColumnName("cd_liked");
		modelBuilder.Entity<LikeOrDislikeRegister>().Property("PostId").IsRequired();
		modelBuilder.Entity<LikeOrDislikeRegister>().Property("PostId").HasColumnName("cd_post");
		modelBuilder.Entity<LikeOrDislikeRegister>().Property("ProfileId").IsRequired();
		modelBuilder.Entity<LikeOrDislikeRegister>().Property("ProfileId").HasColumnName("cd_profile");
		modelBuilder.Entity<LikeOrDislikeRegister>().HasIndex("Id", "PostId", "ProfileId").IsUnique(true).HasDatabaseName("uk_likes");

		modelBuilder.Entity<ComunityMembership>().Property("Id").HasColumnName("cd_community_members");
		modelBuilder.Entity<ComunityMembership>().Property("CommunityId").IsRequired();
		modelBuilder.Entity<ComunityMembership>().Property("CommunityId").HasColumnName("cd_community");
		modelBuilder.Entity<ComunityMembership>().Property("ProfileId").IsRequired();
		modelBuilder.Entity<ComunityMembership>().Property("ProfileId").HasColumnName("cd_profile");
		modelBuilder.Entity<ComunityMembership>().HasIndex("Id", "CommunityId", "ProfileId").IsUnique(true).HasDatabaseName("uk_com_members");

		modelBuilder.Entity<CommunityRequestMembership>().Property("Id").HasColumnName("cd_community_request_membership");
		modelBuilder.Entity<CommunityRequestMembership>().Property("CommunityId").IsRequired();
		modelBuilder.Entity<CommunityRequestMembership>().Property("CommunityId").HasColumnName("cd_community");
		modelBuilder.Entity<CommunityRequestMembership>().Property("ProfileId").IsRequired();
		modelBuilder.Entity<CommunityRequestMembership>().Property("ProfileId").HasColumnName("cd_profile");
		modelBuilder.Entity<CommunityRequestMembership>().HasIndex("Id", "CommunityId", "ProfileId").IsUnique(true).HasDatabaseName("uk_members_request");
	}
}