using aspnet_tut1.Contracts;
using aspnet_tut1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_tut1.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
         private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var allLeaveHistories = _db.LeaveHistories.ToList();
            return allLeaveHistories;
        }

        public LeaveHistory FindBy(int id)
        {
            var foundLeaveHistory = _db.LeaveHistories.Find(id);
            return foundLeaveHistory;
        }

        public bool isExists(int id)
        {
            return _db.LeaveHistories.Any(q => q.Id == id);

        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
