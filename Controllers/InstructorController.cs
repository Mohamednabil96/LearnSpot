using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TaskDay2.Migrations;
using TaskDay2.Models;

namespace TaskDay2.Controllers
{
    public class InstructorController : Controller
    {
        MyDbContext context = new MyDbContext();

        // Index (All Instructors Table)
        public IActionResult Index(string searchString)
        {
            using (var context = new MyDbContext())
            {
                var instructors = from i in context.Instructor
                                  select i;

                if (!string.IsNullOrEmpty(searchString))
                {
                    instructors = instructors.Where(s => s.InsName.Contains(searchString));
                }

                return View(instructors.ToList());
            }
        }

        // Details (1 Instructor only)
        public IActionResult Details(int id)
        {
            using (var context = new MyDbContext())
            {
                var instructor = context.Instructor.Find(id);
                return View(instructor);
            }
        }

        // Create Instructor
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
            ViewBag.CourseList = new SelectList(context.Course.ToList(), "CrsId", "CrsName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructor.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
            ViewBag.CourseList = new SelectList(context.Course.ToList(), "CrsId", "CrsName");
            return View(instructor);
        }

        // Edit Instructor 
        public IActionResult Edit(int id)
        {
            var instructor = context.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
            ViewBag.CourseList = new SelectList(context.Course.ToList(), "CrsId", "CrsName");
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor instructor)
        {
            if (id != instructor.InsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                context.Update(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
            ViewBag.CourseList = new SelectList(context.Course.ToList(), "CrsId", "CrsName");
            return View(instructor);
        }

        // Delete Instructor 
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var instructor = context.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }
            context.Instructor.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
