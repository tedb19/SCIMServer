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
			builder.Entity<Group>().HasMany(p => p.Users).WithOne(p => p.Group).HasForeignKey(p => p.GroupId).IsRequired(false);

			builder.Entity<Group>().HasData
			(
				new Group { Id = 100, Name = "Identity" },
				new Group { Id = 101, Name = "MS Graph" }
			);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<User>().HasKey(p => p.Id);
			builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<User>().OwnsOne(p => p.Name); //https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
			builder.Entity<User>().OwnsOne(p => p.Address);
			builder.Entity<User>().Property(p => p.Email).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.UserName).IsRequired().HasMaxLength(50);
			builder.Entity<User>().Property(p => p.ExternalId).HasMaxLength(70);
			builder.Entity<User>(b =>
			{
				b.HasData(new User
				{
					Id = 100,
					Email = "teddy.odhiambo@example.com",
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
			});
        }
	}
}
