using E_Commerce.Api.Validators;
using E_Commerce.Common.DTOs;
using E_Commerce.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers;

[Route("api/[controller]")]
public class OrdersController : Controller
{
	private readonly ICreateService<OrderDto> _createService;
	private readonly ICreateValidator<OrderDto> _validator;

	public OrdersController(ICreateValidator<OrderDto> validator, ICreateService<OrderDto> createService)
	{
		_validator = validator;
		_createService = createService;
	}

	[HttpPost("Create")]
	public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
	{
		if (orderDto is null) return BadRequest();

		var badRequestError = _validator.ValidateCreate(orderDto);
		if (badRequestError is not null) return BadRequest(badRequestError);

		await _createService.Create(orderDto, HttpContext.User.Identity!.Name);
		return Ok();
	}
}