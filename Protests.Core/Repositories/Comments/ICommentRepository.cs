using System.Collections.Generic;
using Protests.Data.Entities;

namespace Protests.Core.Repositories.Comments
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetByProtest(long protestId);
    }
}