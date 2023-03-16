using E_Commerce.Common.DatabaseModels;
using E_Commerce.Common.DTOs;
using E_Commerce.DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DataAccess.Service;

public class OrderService : ICreateService<OrderDto>
{
	private readonly Context _context;
	private DbSet<Order> Orders => _context.Set<Order>();
	private DbSet<Customer> Customers => _context.Set<Customer>();
	private DbSet<OrderDetail> OrderDetails => _context.Set<OrderDetail>();

	public OrderService(Context context)
	{
		_context = context;
	}

	public async Task Create(OrderDto orderDto, string user)
	{
		var guid = Guid.NewGuid().ToString();
		var customer = new Customer();

		if (orderDto.CustomerId is null || !Customers.Any(c => c.CustomerId == orderDto.CustomerId))
		{
			var newCustomer = new Customer
			{
				Name = orderDto.CustomerName,
				RowGuid = guid
			};

			await Customers.AddAsync(newCustomer);
			await _context.SaveChangesAsync();
			customer = await Customers.SingleAsync(c => c.RowGuid == guid);
		}
		else
		{
			customer.CustomerId = orderDto.CustomerId.Value;
		}

		await Orders.AddAsync(new Order
		{
			OrderDate = orderDto.OrderDate,
			CustomerId = customer.CustomerId,
			CreatedUser = user,
			CreatedDateTimeUTC = DateTime.UtcNow,
			RowGuid = guid
		});
		await _context.SaveChangesAsync();

		var order = await Orders.SingleAsync(o => o.RowGuid == guid);

		var orderDetails = orderDto.OrderDetails.Select(od => new OrderDetail
		{
			OrderId = order.OrderId,
			ProductId = od.ProductId,
			Quantity = od.Quantity
		});

		await OrderDetails.AddRangeAsync(orderDetails);
		await _context.SaveChangesAsync();
	}
}