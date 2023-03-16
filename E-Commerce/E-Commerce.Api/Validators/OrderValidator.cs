using E_Commerce.Common;
using E_Commerce.Common.DatabaseModels;
using E_Commerce.Common.DTOs;
using E_Commerce.DataAccess.DBContext;

namespace E_Commerce.Api.Validators;

public class OrderValidator : ICreateValidator<OrderDto>
{
	private readonly Context _context;

	public OrderValidator(Context context)
	{
		_context = context;
	}

	public BadRequestResponse ValidateCreate(OrderDto orderDto)
	{
		var errors = new List<string>();

		if (orderDto.CustomerId is null && orderDto.CustomerName is null)
		{
			errors.Add("A CustomerId or a CustomerName must be provided.");
			return new BadRequestResponse(errors);
		}

		if (orderDto.CustomerId is not null)
			if (!_context.Set<Customer>().Any(c => c.CustomerId == orderDto.CustomerId))
			{
				errors.Add($"Customer with CustomerId {orderDto.CustomerId} does not exist.");
				return new BadRequestResponse(errors);
			}

		foreach (var orderDetail in orderDto.OrderDetails)
			if (!_context.Set<Product>().Any(p => p.ProductId == orderDetail.ProductId))
				errors.Add($"Product with ProductId {orderDetail.ProductId} does not exist");

		return !errors.Any() ? null : new BadRequestResponse(errors);
	}
}