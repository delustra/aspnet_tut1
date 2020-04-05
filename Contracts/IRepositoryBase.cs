using System.Collections.Generic;

namespace aspnet_tut1.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll();

        T FindBy(int id);

        bool Create(T entity);

        bool Update(T entity);
        bool Delete(T entity);

        bool Save();
    }
}