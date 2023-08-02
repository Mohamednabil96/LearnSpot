using System;
using System.ComponentModel.DataAnnotations;

namespace TaskDay2.Models
{
    public class UniqueCrsNamePerDeptAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = validationContext.ObjectInstance as Course;
            var context = (MyDbContext)validationContext.GetService(typeof(MyDbContext));
            var otherCourse = context.Course.FirstOrDefault(c => c.CrsName == course.CrsName && c.DeptId == course.DeptId);

            if (otherCourse != null && otherCourse.CrsId != course.CrsId)
            {
                return new ValidationResult("A course with the same name already exists in this department.");
            }

            return ValidationResult.Success;
        }
    }
}
