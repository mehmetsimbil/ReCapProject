using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapProjectDbContext reCapProjectDbContext = new ReCapProjectDbContext())
            {
                var addedEntity = reCapProjectDbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectDbContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectDbContext reCapProjectDbContext = new ReCapProjectDbContext())
            {
                var deletedEntity = reCapProjectDbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectDbContext.SaveChanges();
            }

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDbContext reCapProjectDbContext = new ReCapProjectDbContext())
            {
                return filter == null 
                    ? reCapProjectDbContext.Set<Car>().ToList() 
                    : reCapProjectDbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectDbContext reCapProjectDbContext = new ReCapProjectDbContext())
            {
                return reCapProjectDbContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectDbContext reCapProjectDbContext = new ReCapProjectDbContext())
            {
                var updatedEntity = reCapProjectDbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectDbContext.SaveChanges();
            }
        }
    }
}
