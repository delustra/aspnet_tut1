using aspnet_tut1.Contracts;
using aspnet_tut1.Data;
using aspnet_tut1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_tut1.Controllers
{
    [Authorize(Roles ="administrator")]
    public class LeaveTypesController : Controller
    {

        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       
        // GET: LeaveTypes
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<DetailedLeaveTypeViewModel>>(leavetypes);
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            
                if (!_repo.isExists(id))
                {
                    return NotFound();
                }

                var leaveType = _repo.FindBy(id);
                var mappedLeaveType = _mapper.Map<DetailedLeaveTypeViewModel>(leaveType);

                return View(mappedLeaveType);
            
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetailedLeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }
                var mappedleaveType = _mapper.Map<LeaveType>(model);
                mappedleaveType.DateCreated = DateTime.Now;

                var isCreated = _repo.Create(mappedleaveType);


                if (!isCreated)
                {
                    ModelState.AddModelError("", "Creation went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var leaveType = _repo.FindBy(id);
            var mappedLeaveType = _mapper.Map<DetailedLeaveTypeViewModel>(leaveType);

            return View(mappedLeaveType);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailedLeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(); 
                }

                var mappedLeaveType = _mapper.Map<LeaveType>(model);
                var isSuccess = _repo.Update(mappedLeaveType);
                
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Update went wrong");
                    return View(model);
                }
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Update went wrong");
                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var model = _repo.FindBy(id);
            var mappedLeaveType = _mapper.Map<LeaveType>(model);
            var isSuccess = _repo.Delete(mappedLeaveType);

            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DetailedLeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var mappedLeaveType = _mapper.Map<LeaveType>(model);
                var isSuccess = _repo.Delete(mappedLeaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Delete went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}