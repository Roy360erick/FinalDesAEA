using Common.HttpHelpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceBase<T>
    {
        EResponseBase<T> GetList();
        EResponseBase<T> Get(int ID);
        EResponseBase<T> Add(T model);
        EResponseBase<T> Update(T model);
        EResponseBase<T> Delete(int ID);

    }
}
