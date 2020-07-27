using Microsoft.EntityFrameworkCore;
using Protests.Data.Database;
using Protests.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protests.Core.Repositories.Protests
{
    public class ProtestRepository : IProtestRepository
    {
        private readonly ProtestsContext context;

        public ProtestRepository(ProtestsContext context) => this.context = context;

        public Protest Create(Protest entity)
        {
            this.context.Protests.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Protests.Remove(this.GetOne(id));
            this.context.SaveChanges();
            /* if here, command executed without exception */
            return true;
        }

        public IEnumerable<Protest> GetAll(string search)
        {
            var query = this.context.Protests.AsQueryable();
            query = query.Include(p => p.City); // INNER JOIN
            query = query.Include(p => p.Organizer); // INNER JOIN
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Title.Contains(search) ||
                         p.Description.Contains(search)
                );
            }

            // SELECT * FROM protests WHERE title LIKE '%nekarijec%' OR description LIKE '%nekarijec'

            return query.ToList();
        }

        public Protest GetOne(long id) =>
            this.context.Protests
                .Include(p => p.Comments)
                .Include(p => p.City)
                .Where(p => p.Id == id)
                .First<Protest>();

        public Protest Update(long id, Protest doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}
