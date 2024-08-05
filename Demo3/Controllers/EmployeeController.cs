using AutoMapper;
using Castle.Core.Internal;
using Demo3.Helpers;
using Demo3.ViewModels;
using DemoBLL.Interfaces;
using DemoBLL.Repositories;
using DemoDAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Demo3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;



        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        //[HttpGet]
        public IActionResult Index(string SearchInput)
        {
            ///ViewData["Message2"] = "Hello From View Data";
            ///Console.WriteLine();
            ///View Bag.Message = "Hello From View Bag ";
            ///TempData.Keep();
            ///

            var employee = Enumerable.Empty<Employee>();

            if (SearchInput.IsNullOrEmpty())
                employee = _unitOfWork.EmployeeRepository.GetAll();
            else
                employee = _unitOfWork.EmployeeRepository.GetEmployeeByName(SearchInput.ToLower());

            var MappedEmp = _mapper.Map < IEnumerable<Employee>, IEnumerable< EmployeeViewModel > >(employee);

            return View(MappedEmp);

        }

        public IActionResult Create()
        {
            //ViewData["DeptRepo"] = _deptRepo.GetAll();  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if(ModelState.IsValid)
            {
               employeeViewModel.ImageName=  DocumentSetting.UploadFile(employeeViewModel.Image, "Images");

                ///var mappedEmp = new Employee
                ///{
                ///    Id = employeeViewModel.Id,
                ///    Name = employeeViewModel.Name,
                ///    Age = employeeViewModel.Age,
                ///    Adresss=employeeViewModel.Adresss,
                ///    IsActive=employeeViewModel.IsActive,
                ///    HireDate=employeeViewModel.HireDate,
                ///    DepartmentId=employeeViewModel.DepartmentId
                ///};

                var  mappedEmp  =_mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Add(mappedEmp);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    TempData["Message"] = "Employee Created Succesfully ";
                else
                    TempData["Message"] = "An Error Has Happened and The department Didn't Created ";

                return RedirectToAction(nameof(Index));

            }
            return View(employeeViewModel);
        }


        public IActionResult Details(int? id, string view= "Details")
        {
            if (id == null)
                return BadRequest();
               var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if(employee == null)
                return NotFound();

            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(view, mappedEmp);
        }


        public IActionResult Update(int? id)
        {
            //ViewData["DeptRepo"] = _deptRepo.GetAll();

            return Details(id,"Update");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute]int id,EmployeeViewModel employee)
        {
             if(id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                if (employee.ImageName != null)
                    DocumentSetting.DeleteFile(employee.ImageName, "Images");
                employee.ImageName = DocumentSetting.UploadFile(employee.Image, "Images");

                var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employee);


                try
                {
                    _unitOfWork.EmployeeRepository.Update(MappedEmp);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(employee);

                }
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id ,EmployeeViewModel employee)
        {
            if (id != employee.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {


               var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employee);
                try
                {
                    _unitOfWork.EmployeeRepository.Delete(MappedEmp);
                    int count =_unitOfWork.Complete();
                    if(count > 0) 
                    DocumentSetting.DeleteFile(employee.ImageName,"Images");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError (string.Empty, e.Message);
                    return View(employee);
                    
                }
            }

            return View(employee);

        }
    }
}
