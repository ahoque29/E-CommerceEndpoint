using System.Text.Json.Serialization;

namespace E_Commerce.Common.DatabaseModels;

public class OrderDetail
{
	[JsonIgnore] public int OrderDetailsId { get; set; }
	[JsonIgnore] public int OrderId { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	[JsonIgnore] public Order Order { get; set; }
	[JsonIgnore] public Product Product { get; set; }
}