using Microsoft.EntityFrameworkCore;
using SCIMServer.Domain.Models;

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
			builder.Entity<Group>().HasData
			(
				new Group { Id = 100, Name = "Identity" },
				new Group { Id = 101, Name = "MS Graph" }
			);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<User>().HasKey(p => p.Id);
			builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Entity<User>().Property(p => p.Name.FamilyName).IsRequired().HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Name.GivenName).IsRequired().HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Email).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.UserName).IsRequired().HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Address.City).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Address.Country).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Address.PostalCode).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.Address.Region).HasMaxLength(50);
			builder.Entity<User>().Property(p => p.ExternalId).HasMaxLength(70);

			builder.Entity<User>().HasData
			(
				new User
				{
					Id = "476ac62a-002a-47cc-88f7-76998b0a76bc",
					Address = { Region = "Astada Apartments, Garden Est.", City = "Nairobi", Country = "Kenya" },
					Name = { FamilyName = "Odhiambo", GivenName = "Teddy" }, 
					Email = "teddy.odhiambo@example.com",
					Status = EStatus.Active,
					UserName = "teddyO",
					GroupId = 100
				}
			);

		}
	}
}
