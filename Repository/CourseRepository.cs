using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskDay2.Models;
using TaskDay2.Repository;

namespace TaskDay2.Repository
{
    public class CourseRepository : ICourseRepository
    {
        MyDbContext _context;

        public CourseRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCoursesWithDepartment()
        {
            return _context.Course.Include(c => c.Department).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Course.FirstOrDefault(c => c.CrsId == id);
        }

        public void AddCourse(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course course = _context.Course.Find(id);
            _context.Course.Remove(course);
            _context.SaveChanges();
        }
    }
}

