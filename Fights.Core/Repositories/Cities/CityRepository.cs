using Microsoft.EntityFrameworkCore;
using Fights.Core.Repositories.Cities;
using Fights.Data.Database;
using Fights.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fights.Core.Repositories.Protests
{
    public class CityRepository : ICityRepository
    {
        private readonly ProtestsContext context;

        public CityRepository(ProtestsContext context) => this.context = context;

        public City Create(City entity)
        {
            this.context.Cities.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Cities.Remove(this.GetOne(id));
            this.context.SaveChanges();
            /* if here, command executed without exception */
            return true;
        }

        public IEnumerable<City> GetAll(string search)
        {
            var query = this.context.Cities.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.CityName.Contains(search)
                );
            }

            // SELECT * FROM cities WHERE cityName LIKE '%nekarijec%'

            return query.ToList();
        }

        public City GetOne(long id) =>
            this.context.Cities
                .Where(p => p.Id == id)
                .First<City>();

        public City Update(long id, City doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}
