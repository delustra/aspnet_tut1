using aspnet_tut1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_tut1.Contracts

{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>

    {

        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
    }
}
