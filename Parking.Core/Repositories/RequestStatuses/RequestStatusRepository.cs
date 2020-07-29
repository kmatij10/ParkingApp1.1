using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.RequestStatuses
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ParkingContext context;

        public RequestStatusRepository(ParkingContext context)
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
        public RequestStatus Update(long id, RequestStatus newRequestStatus)
        {
            newRequestStatus.Id = id;
            this.context.Entry(newRequestStatus).State = EntityState.Modified;
            this.context.SaveChanges();

            return newRequestStatus;
        }
    }
}