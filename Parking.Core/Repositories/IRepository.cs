using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;

namespace Parking.Core.Repositories
{
    public interface IRepository<T>
    {
        T GetOne(long id);

        IEnumerable<T> GetAll(string search);

        bool Delete(long id);

        T Create(T entity);

    }
}
