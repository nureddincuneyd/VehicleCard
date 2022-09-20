using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehicleCard.DAL.Context;
using VehilceCard.ENT.Models;

namespace VehicleCard.BLL.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly MyContext _context;
        protected DbSet<T> _table;
        public Repository(MyContext db)
        {
            _context = db;
            _table = db.Set<T>();
        }
        private void Save()
        {
            _context.SaveChangesAsync();
        }
        public T Create(T entity)
        {
            _table.AddAsync(entity);
            Save();
            return entity;
        }

        public T Delete(int id)
        {
            T item = GetById(id);
            _table.Remove(item);
            Save();
            return item;
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return _table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return _table.FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            Save();
            return entity;
        }
    }
}
