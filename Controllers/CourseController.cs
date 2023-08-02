using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskDay2.Controllers;
using TaskDay2.Models;
using TaskDay2.Repository;
using TaskDay2.Repository;
using TaskDay2.ViewModels;

namespace TaskDay2.Controllers
{
    public class CourseController : Controller
    {
        IDepartmentRepository _departmentRepository;
        ICourseRepository _courseRepository;
        
        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateCrsMinDegree(int CrsMinDegree, int CrsDegree)
        {
            if (CrsMinDegree >= CrsDegree)
            {
                return Json($"Course Minimum Degree must be lower than Course Degree.");
            }

            return Json(true);
        }

        // Index (All Courses Table) + Search
        public IActionResult Index(string searchString)
        {
            var courses = _courseRepository.GetAllCoursesWithDepartment();

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CrsName.Contains(searchString)).ToList();
            }

            return View(courses);
        }

        // Details (1 Course only)
        public IActionResult Details(int id)
        {
            Course course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // Create Course
        public IActionResult Create()
        {
            ViewBag.DepartmentList = _departmentRepository.GetAllDepartments().Select(d => new SelectListItem
            {
                Value = d.DeptId.ToString(),
                Text = d.DeptName
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    _courseRepository.AddCourse(course);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DepId", "Please Select a Department");
                }
                
            }
            ViewBag.DepartmentList = _departmentRepository.GetAllDepartments().Select(d => new SelectListItem
            {
                Value = d.DeptId.ToString(),
                Text = d.DeptName
            });
            return View(course);
        }


        // Edit Course 
        public IActionResult Edit(int id)
        {
            Course course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentList = new SelectList(_departmentRepository.GetAllDepartments(), "DeptId", "DeptName");
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.CrsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid == true)
            {
                try
                {
                    _courseRepository.UpdateCourse(course);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. The course was deleted by another user.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            ViewBag.DepartmentList = new SelectList(_departmentRepository.GetAllDepartments(), "DeptId", "DeptName");
            return View(course);
        }

        // Delete Course 
        public IActionResult Delete(int id)
        {
            Course course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        //public class CourseController : Controller
        //{
        //    MyDbContext context = new MyDbContext();

        //    [AcceptVerbs("GET", "POST")]
        //    public IActionResult ValidateCrsMinDegree(int CrsMinDegree, int CrsDegree)
        //    {
        //        if (CrsMinDegree >= CrsDegree)
        //        {
        //            return Json($"Course Minimum Degree must be lower than Course Degree.");
        //        }

        //        return Json(true);
        //    }

        //    // Index (All Courses Table) + Search
        //    public IActionResult Index(string searchString)
        //    {
        //        var courses = context.Course.Include(c => c.Department).ToList();

        //        if (!string.IsNullOrEmpty(searchString))
        //        {
        //            courses = courses.Where(c => c.CrsName.Contains(searchString)).ToList();
        //        }

        //        return View(courses);
        //    }

        //    // Details (1 Course only)
        //    public IActionResult Details(int id)
        //    {
        //        using (var context = new MyDbContext())
        //        {
        //            var course = context.Course.Find(id);
        //            return View(course);
        //        }
        //    }

        //    // Create Course
        //    public IActionResult Create()
        //    {
        //        ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Create(Course course)
        //    {
        //        if (ModelState.IsValid == true)
        //        {
        //            try {
        //                context.Course.Add(course);
        //                context.SaveChanges();
        //                return RedirectToAction("Index");

        //            }catch (Exception ex)
        //            {
        //                ModelState.AddModelError("DeptId", "Please Select a Department");
        //            }
        //        }
        //        ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
        //        return View(course);
        //    }


        //    // Edit Course 
        //    public IActionResult Edit(int id)
        //    {
        //        var course = context.Course.Find(id);
        //        if (course == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
        //        return View(course);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Edit(int id, Course course)
        //    {
        //        if (id != course.CrsId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid==true)
        //        {
        //            context.Update(course);
        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.DepartmentList = new SelectList(context.Department.ToList(), "DeptId", "DeptName");
        //        return View(course);
        //    }

        //    // Delete Course 
        //    [HttpPost]
        //    public IActionResult Delete(int id)
        //    {
        //        var course = context.Course.Find(id);
        //        if (course == null)
        //        {
        //            return NotFound();
        //        }
        //        context.Course.Remove(course);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}

    }
}



