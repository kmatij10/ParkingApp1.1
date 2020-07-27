using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fights.Data.Database;
using Fights.Data.Entities;

namespace Fights.Core.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ProtestsContext context;

        public CommentRepository(ProtestsContext context) => this.context = context;

        public Comment Create(Comment entity)
        {
            this.context.Comments.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            this.context.Comments.Remove(
                this.context.Comments.Find(id)
            );
            this.context.SaveChanges();
            /* if here, command executed without exception */
            return true;
        }

        public IEnumerable<Comment> GetAll(string search)
        {
            var query = this.context.Comments.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    c => c.CommentText.Contains(search)
                );
            }

            return query.ToList();
        }

        public IEnumerable<Comment> GetByProtest(long protestId)
        {
            return this.context.Comments
                .Where(c => c.ProtestId == protestId)
                .ToList();
        }

        public Comment GetOne(long id) =>
            this.context.Comments
                .Include(c => c.Protest)
                .Where(c => c.Id == id)
                .First<Comment>();

        public Comment Update(long id, Comment entity)
        {
            entity.Id = id;
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }
    }
}