using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IRequestStatusRepository : IRepository<RequestStatus>
    {
        public RequestStatus Patch(long id, JsonPatchDocument<RequestStatus> doc);
    }
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ApplicationContext context;

        public RequestStatusRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<RequestStatus> GetAll(string search)
        {
            return this.context.RequestStatuses.ToList();
        }
        public RequestStatus GetOne(long id)
        {
            return this.context.RequestStatuses.Where(c => c.Id == id).Single();
        }
        public RequestStatus Create(RequestStatus c)
        {
            this.context.RequestStatuses.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.RequestStatuses.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public RequestStatus Patch(long id, JsonPatchDocument<RequestStatus> doc)
        {
            var req = this.GetOne(id);
            doc.ApplyTo(req);
            this.context.SaveChanges();
            return req;
        }
    }
}