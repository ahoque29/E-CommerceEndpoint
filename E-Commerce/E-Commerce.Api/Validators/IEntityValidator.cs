using E_Commerce.Common;

namespace E_Commerce.Api.Validators;

public interface ICreateValidator<in T>
{
	BadRequestResponse ValidateCreate(T obj);
}