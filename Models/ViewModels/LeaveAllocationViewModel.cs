
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnet_tut1.Models
{
    public class LeaveAllocationViewModel
    {

        public int Id { get; set; }
        [Required]
        public int NumberofDays { get; set; }
        public DateTime DateCreated { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }
        public int Period { get; set; }
        public DetailedLeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }


    }

    public class CreateLeaveAllocationViewModel
    {
        public int NumberUpdated { get; set; }
        public List<DetailedLeaveTypeViewModel> LeaveTypes { get; set; }

    }

    public class ViewAllocationsViewModel 
    {
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeID { get; set; }
        public List<LeaveAllocationViewModel> LeaveAllocationsList { get; set; }

    }
}
