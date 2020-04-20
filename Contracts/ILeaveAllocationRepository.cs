using aspnet_tut1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_tut1.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leavetypeid, string employeeeid);

        /// <summary>
        /// Find all leave allocations by userid. 
        /// </summary>
        /// <returns></returns>
        List<LeaveAllocation> FindAllByUser(string employeeid);
    }
}
