using aspnet_tut1.Contracts;
using aspnet_tut1.Data;
using aspnet_tut1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_tut1.Controllers
{
    [Authorize(Roles = "administrator")]
    public class LeaveAllocationController : Controller
    {


        private readonly ILeaveAllocationRepository _leaveallocationrepo;
        private readonly ILeaveTypeRepository _leavetyperepo;
        private readonly UserManager<Employee> _usermanager;
        private readonly IMapper _mapper;
        public int numberofchanges;


        public LeaveAllocationController(
            ILeaveAllocationRepository leaveallocationrepo,
            ILeaveTypeRepository leavetyperepo,
            IMapper mapper,
            UserManager<Employee> usermanager
            )
        {
            _leaveallocationrepo = leaveallocationrepo;
            _leavetyperepo = leavetyperepo;
            _mapper = mapper;
            _usermanager = usermanager;
            numberofchanges = 5;
        }


        // GET: LeaveAllocationController
        public ActionResult Index(int b)
        {
            var leavetypes = _leavetyperepo.FindAll().ToList();
            var mappedLeaveTypesmodel = _mapper.Map<List<LeaveType>, List<DetailedLeaveTypeViewModel>>(leavetypes);
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypesmodel,
                NumberUpdated = b
            };

            return View(model);

        }

        public ActionResult SetLeave(int id)
        {
            var requestedrole = "employee";
            var leavetype = _leavetyperepo.FindBy(id);
            var employees = _usermanager.GetUsersInRoleAsync(requestedrole).Result;
            numberofchanges = 2;
            foreach (var employee in employees)
            {
                if (_leaveallocationrepo.CheckAllocation(id, employee.Id))
                    continue;
                var allocation = new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = employee.Id,
                    LeaveTypeId = id,
                    NumberofDays = leavetype.DefaultDays,
                    Period = DateTime.Now.Year
                };
                numberofchanges += 4;
                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                _leaveallocationrepo.Create(leaveallocation);
            }
            return RedirectToAction(nameof(Index), new { id = numberofchanges });
        }

        public ActionResult ListEmployees()
        {
            var requestedrole = "employee";
            var employees = _usermanager.GetUsersInRoleAsync(requestedrole).Result;
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public ActionResult Details(string id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_usermanager.FindByIdAsync(id).Result);
            var period = DateTime.Now.Year;
            var allocations = _mapper.Map<List<LeaveAllocationViewModel>>(_leaveallocationrepo.FindAllByUser(id));

            var model = new ViewAllocationsViewModel
            {
                Employee = employee,
                EmployeeID = id,
                LeaveAllocationsList = allocations
            };




            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
