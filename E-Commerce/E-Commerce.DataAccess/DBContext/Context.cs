using E_Commerce.Common.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DataAccess.DBContext;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> opts) : base(opts)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Order>(e => e.ToTable("Order", "Main"));

		modelBuilder.Entity<Customer>(e => e.ToTable("Customer", "Main"));

		modelBuilder.Entity<Product>(e => e.ToTable("Product", "Main"));

		modelBuilder.Entity<OrderDetail>(e =>
		{
			e.ToTable("OrderDetail", "Main");
			e.HasKey(t => new
			{
				t.OrderId,
				t.ProductId
			});
		});
	}
}