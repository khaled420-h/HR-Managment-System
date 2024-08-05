using AutoMapper;
using Demo3.ViewModels;
using DemoBLL.Interfaces;
using DemoBLL.Repositories;
using DemoDAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Demo3.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork,IMapper mapper/*,IDepartmentRepository departmentRepository*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll();

            var MappedDept = _mapper.Map<IEnumerable<Department>,IEnumerable< DepartmentViewModel>>(department);
            return View(MappedDept);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel department)
        {
           if(ModelState.IsValid) //server Side Validation 
            {
                var MappedDept =_mapper.Map<DepartmentViewModel,Department>(department);
                _unitOfWork.DepartmentRepository.Add(MappedDept);
                _unitOfWork.Complete();
                return  RedirectToAction("Index");
            }
           else { return View(department); }
        }

        public IActionResult Details(int? id,string view="Details")
        {
            if(id == null)
            {
                return BadRequest();
            }
            var department = _unitOfWork.DepartmentRepository.Get(id.Value);

            if(department == null)
                return NotFound();

            var MappedDept = _mapper.Map<Department, DepartmentViewModel>(department);

             return View(MappedDept); 
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ///    if (id == null) return BadRequest();
            ///var department = _departmentRepository.Get(id.Value);
            ///if (department == null)
            ///    return NotFound();
            ///return View(department);
            
           return Details(id, "Update");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute]int id ,DepartmentViewModel department)
        {
            if(id != department.Id) { return BadRequest(); }
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedDept = _mapper.Map<DepartmentViewModel, Department>(department);

                    _unitOfWork.DepartmentRepository.Update(MappedDept);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1. Log Exception 
                    //2. Friendly Message 
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(department);
                }
            }
            else
            {
                return View(department); 
            }


        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {

             return Details(id, "Delete");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, DepartmentViewModel department)
        {
            if (id != department.Id)
                return BadRequest (); 

                try
                {
                var MappedDept = _mapper.Map<DepartmentViewModel, Department>(department);
                _unitOfWork.DepartmentRepository.Delete(MappedDept);
                _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(department);
                }
            
        }

    }
}
