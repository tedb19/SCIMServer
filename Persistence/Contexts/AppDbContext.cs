using Microsoft.EntityFrameworkCore;
using SCIMServer.Domain.Models;
using System;

namespace SCIMServer.Persistence.Contexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Group> Groups { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Group>().ToTable("Groups");
			builder.Entity<Group>().HasKey(p => p.Id);
			builder.Entity<Group>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<Group>().Property(p => p.Name).IsRequired().HasMaxLength(30);
			builder.Entity<Group>().HasMany(p => p.Users).WithOne(p => p.Group).HasForeignKey(p => p.GroupId);
			builder.Entity<Group>().OwnsOne(p => p.Meta).Property(p => p.Created).HasDefaultValueSql("datetime('now')");
			builder.Entity<Group>().OwnsOne(p => p.Meta).Property(p => p.LastModified).HasDefaultValueSql("datetime('now')");

			builder.Entity<Group>(group =>
			{
				group.HasData(new Group
				{
					Id = 100,
					Name = "Identity"
				});
				group.OwnsOne(e => e.Meta).HasData(new
				{
					GroupId = 100,
					ResourceType = EResourceType.Group,
					Created = DateTime.Now,
					LastModified = DateTime.Now
				});
			});
			builder.Entity<Group>(group =>
			{
				group.HasData(new Group
				{
					Id = 101,
					Name = "MS Graph"
				});
				group.OwnsOne(e => e.Meta).HasData(new
				{
					GroupId = 101,
					ResourceType = EResourceType.Group,
					Created = DateTime.Now,
					LastModified = DateTime.Now
				});
			});
			builder.Entity<User>().ToTable("Users");
			builder.Entity<User>().HasKey(p => p.Id);
			builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<User>().OwnsOne(p => p.Name); //https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
			builder.Entity<User>().OwnsOne(p => p.Address);
			builder.Entity<User>().OwnsOne(p => p.Meta).Property(p => p.Created).HasDefaultValueSql("datetime('now')");
			builder.Entity<User>().OwnsOne(p => p.Meta).Property(p => p.LastModified).HasDefaultValueSql("datetime('now')");
			builder.Entity<User>().Property(p => p.UserName).IsRequired().HasMaxLength(50);
			builder.Entity<User>().Property(p => p.ExternalId).HasMaxLength(70);
			builder.Entity<User>().HasMany(p => p.Emails).WithOne(p => p.User).HasForeignKey(p => p.UserId);
			builder.Entity<User>(b =>
			{
				b.HasData(new User
				{
					Id = 100,
					Status = EStatus.Active,
					UserName = "teddyO",
					GroupId = 100
				});
				b.OwnsOne(e => e.Address).HasData(new
				{
					UserId = 100,
					Region = "Astada Apartments, Garden Est.",
					City = "Nairobi",
					Country = "Kenya"
				});
				b.OwnsOne(e => e.Name).HasData(new
				{
					UserId = 100,
					FamilyName = "Odhiambo",
					GivenName = "Teddy"
				});
				b.OwnsOne(e => e.Meta).HasData(new
				{
					UserId = 100,
					ResourceType = EResourceType.User,
					Created = DateTime.Now,
					LastModified = DateTime.Now
				});
			});
			builder.Entity<Email>().ToTable("Emails");
			builder.Entity<Email>().HasKey(p => p.Id);
			builder.Entity<Email>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<Email>().Property(p => p.Value).HasMaxLength(80);
			builder.Entity<Email>().Property(p => p.Primary).HasDefaultValue(false);
			builder.Entity<Email>().Property(p => p.Type).HasDefaultValue(EType.Work);

			builder.Entity<Email>(email =>
			{
				email.HasData(new Email
				{
					Id = 100,
					Type = EType.Home,
					UserId = 100,
					Value = "teddyO@yahoo.com",
					Primary = true
				});
			});
			builder.Entity<Email>(email =>
			{
				email.HasData(new Email
				{
					Id = 101,
					Type = EType.Work,
					UserId = 100,
					Value = "teddyO@example.com"
				});
			});
		}
	}
}
