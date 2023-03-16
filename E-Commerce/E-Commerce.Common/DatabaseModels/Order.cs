namespace E_Commerce.Common.DatabaseModels;

public class Order
{
	public int OrderId { get; set; }
	public DateTime OrderDate { get; set; }
	public string CreatedUser { get; set; }
	public DateTime CreatedDateTimeUTC { get; set; }
	public string RowGuid { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
}