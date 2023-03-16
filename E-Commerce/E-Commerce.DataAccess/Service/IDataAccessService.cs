namespace E_Commerce.DataAccess.Service;

public interface ICreateService<in T>
{
	Task Create(T entity, string user);
}