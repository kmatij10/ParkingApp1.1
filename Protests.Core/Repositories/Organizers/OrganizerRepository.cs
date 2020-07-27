using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Protests.Data.Database;
using Protests.Data.Entities;

namespace Protests.Core.Repositories.Organizers
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly ProtestsContext context;

        public OrganizerRepository(ProtestsContext context) => this.context = context;
        
        public Organizer Create(Organizer entity)
        {
            this.context.Organizers.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Organizers.Remove(
                this.GetOne(id)
            );
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Organizer> GetAll(string search)
        {
            var result = this.context.Organizers.ToList();
            return result;
        }

        public Organizer GetOne(long id) => this.context.Organizers
            .Where(o => o.Id == id)
            .First<Organizer>();

        public Organizer Update(long id, Organizer entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}