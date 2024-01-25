using Microsoft.EntityFrameworkCore;
using System;

namespace GuitarStore.Models
{
	public class Context : DbContext
	{
		public DbSet<Order>? Orders { get; set; }
		public DbSet<Guitar>? Guitars { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Stock>? Stocks { get; set; }
		public DbSet<User>? Users { get; set; }
		public DbSet<Like>? Likes { get; set; }
		public DbSet<AddToShoppingCart>? AddToShoppingCarts { get; set; }		
		public Context() { }
		public Context(DbContextOptions<Context> options) : base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine);
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Guitars_store;Username=postgres;Password=a");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasOne(order => order.User)
				.WithMany(user => user.Orders)
				.HasForeignKey(order => order.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Order>()
				.HasOne(order => order.Guitar)
				.WithOne(guitar => guitar.Order)
				.HasForeignKey<Guitar>(guitar => guitar.OrderId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Guitar>()
				.HasKey(guitar => guitar.GuitarId);

			modelBuilder.Entity<Like>()
				.HasKey(like => like.LikeId);

			modelBuilder.Entity<Like>()
			   .HasOne(like => like.Guitar)
			   .WithOne(guitar => guitar.Like)
			   .HasForeignKey<Like>(guitar => guitar.GuitarId)
			   .OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Like>()
				.HasOne(l => l.User)
				.WithMany(u => u.Likes)
				.HasForeignKey(l => l.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<AddToShoppingCart>()
				.HasKey(add => add.AddToShoppingCartId);

			modelBuilder.Entity<AddToShoppingCart>()
			   .HasOne(add => add.Guitar)
			   .WithOne(guitar => guitar.AddToShoppingCart)
			   .HasForeignKey<AddToShoppingCart>(guitar => guitar.GuitarId)
			   .OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<AddToShoppingCart>()
				.HasOne(a => a.User)
				.WithMany(u => u.addToShoppingCarts)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Like>()
				.HasKey(like => like.LikeId);

			modelBuilder.Entity<Like>()
			   .HasOne(like => like.Guitar)
			   .WithOne(guitar => guitar.Like)
			   .HasForeignKey<Like>(guitar => guitar.GuitarId)
			   .OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Like>()
				.HasOne(l => l.User)
				.WithMany(u => u.Likes)
				.HasForeignKey(l => l.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Stock>()
				.HasKey(stock => stock.StockId);

			modelBuilder.Entity<Category>()
				.HasKey(category => category.CategoryId);

			modelBuilder.Entity<Guitar>()
				.HasOne(guitar => guitar.Stock)
				.WithMany(stock => stock.Guitars)
				.HasForeignKey(guitar => guitar.StockId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Guitar>()
				.HasOne(guitar => guitar.Category)
				.WithMany(category => category.Guitars)
				.HasForeignKey(guitar => guitar.CategoryId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			base.OnModelCreating(modelBuilder);
		}
	}
}