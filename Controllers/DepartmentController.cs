using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskDay2.Models;
using TaskDay2.Repository;
using TaskDay2.ViewModels;

namespace TaskDay2.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Index (All Departments Table) + Search
        public IActionResult Index(string searchString)
        {
            var departments = _departmentRepository.GetAllDepartments();

            if (!string.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => d.DeptName.Contains(searchString)).ToList();
            }

            return View(departments);
        }

        // Details (1 Department only)
        public IActionResult Details(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // Create Department
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.AddDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }


        // Edit Department 
        public IActionResult Edit(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.DeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.UpdateDepartment(department);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. The department was deleted by another user.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(department);
        }

        // Delete Department 
        public IActionResult Delete(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _departmentRepository.DeleteDepartment(id);
            return RedirectToAction("Index");
        }


        ////////////////////////////////////////////    Need to be edited     //////////////////////////////////////
        //  GetCoursesByDepartment --> when I Add or Edit instructor, the Course choosen depends on the Department I choosed
        public IActionResult GetCoursesByDepartment(int deptId)
        {
            MyDbContext context = new MyDbContext();
            var courses = context.Course.Where(c => c.DeptId == deptId)
                                           .Select(c => new SelectListItem
                                           {
                                               Value = c.CrsId.ToString(),
                                               Text = c.CrsName
                                           })
                                           .ToList();

            return Json(courses);
        }
    }
}