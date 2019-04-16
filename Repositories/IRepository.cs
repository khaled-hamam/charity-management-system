using System.Collections.Generic;

namespace charity_management_system.Repositories
{
    interface IRepository<T>
    {
        T save(T model);
        List<T> find(string column, string value);
        List<T> findAll();
        T findByID(string id);
        bool update(T newModel);
        bool delete(T model);
    }
}
