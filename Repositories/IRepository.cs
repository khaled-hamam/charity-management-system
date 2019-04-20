using System.Collections.Generic;
using System;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace charity_management_system.Repositories
{
    public interface IRepository<T>
    {
        T save(T model);
        List<T> find(String column, String value);
        List<T> findAll();
        T findByID(String id);
        bool update(T newModel);
        bool delete(T model);
    }
}
