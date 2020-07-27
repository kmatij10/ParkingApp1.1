using System.Collections.Generic;
using Fights.Data.Entities;

namespace Fights.Core.Repositories.Comments
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetByProtest(long protestId);
    }
}