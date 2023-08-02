using System.Collections.Generic;
using TaskDay2.Models;

namespace TaskDay2.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAllCoursesWithDepartment();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}