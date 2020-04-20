using aspnet_tut1.Contracts;
using aspnet_tut1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_tut1.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leavetypeid, string employeeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeeid && q.LeaveTypeId == leavetypeid && q.Period == period)
                .Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }


        public ICollection<LeaveAllocation> FindAll()
        {
            var allLeaveAllocations = _db.LeaveAllocations.Include(q => q.LeaveType).ToList();
            return allLeaveAllocations;
        }

    
        public List<LeaveAllocation> FindAllByUser(string employeeid)
        {
            var period = DateTime.Now.Year;
            
            var LeaveAllocationsList = FindAll()
                 .Where(q => q.EmployeeId == employeeid && q.Period == period)
                 .ToList();
            return LeaveAllocationsList;
        }

        public LeaveAllocation FindBy(int id)
        {
            LeaveAllocation leaveAllocation = _db.LeaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool isExists(int id)
        {
            return _db.LeaveAllocations.Any(q => q.Id == id);

        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
