using E_Commerce.Common.DatabaseModels;

namespace E_Commerce.Common.DTOs;

public class OrderDto
{
	public DateTime OrderDate { get; set; }
	public int? CustomerId { get; set; }
	public string CustomerName { get; set; }
	public IEnumerable<OrderDetail> OrderDetails { get; set; }
}