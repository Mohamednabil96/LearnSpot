using System.Collections.Generic;
using System.Linq;
using TaskDay2.Models;

namespace TaskDay2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MyDbContext _context;

        public DepartmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Department.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Department.FirstOrDefault(d => d.DeptId == id);
        }

        public void AddDepartment(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Department.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            Department department = _context.Department.Find(id);
            if (department != null)
            {
                _context.Department.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}