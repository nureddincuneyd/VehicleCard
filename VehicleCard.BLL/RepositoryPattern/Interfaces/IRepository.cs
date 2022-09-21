using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehilceCard.ENT.Models;

namespace VehicleCard.BLL.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(int id);
        List<T> GetByFilter(Expression<Func<T, bool>> exp);
        List<T> CreateRange(List<T> lEntity);
    }
}
