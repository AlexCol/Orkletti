using backendOrkletti.src.Model.Entity;

namespace backendOrkletti.src.Repository.GenericRepository;

public interface IGenericRepository<T> where T : BaseEntity {
	T FindById(Guid id);
	List<T> FindAll();
	T Create(T item);
	T Update(T item);
	void Delete(Guid id);
}
