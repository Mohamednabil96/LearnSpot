using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDay2.Models;
using TaskDay2.ViewModels;


namespace TaskDay2.Controllers
{
    public class TraineeController : Controller
    {

        private readonly MyDbContext db;

        public TraineeController()
        {
            db = new MyDbContext();
        }

        public IActionResult ShowResult(int tid, int cid)
        {

            TraineeCourseResultViewModel td = new TraineeCourseResultViewModel();

            var trainee = db.CrsResult.Where(c => c.CrsId == cid && c.TraId == tid)
                .Include(c => c.Course)
                .Include(t => t.Trainee).FirstOrDefault();

            td.TraineeName = trainee.Trainee.TraName;
            td.CourseName = trainee.Course.CrsName;
            td.CourseDegree = trainee.CrsResultDegree;

            td.Color = td.CourseDegree > trainee.Course.CrsMinDegree ? "green" : "red";
            return View(td);
            //    /Trainee/ShowResult?tid=1&cid=1
        }



        public IActionResult ShowTraineeResult(int tid)
        {
            var courseList = db.CrsResult.Where(c => c.TraId == tid)
                .Include(c => c.Course)
                .Include(t => t.Trainee).ToList();

            if (courseList == null)
            {
                return NotFound();
            }
            List<TraineeCourseResultViewModel> td = new List<TraineeCourseResultViewModel>();

            for (int i = 0; i < courseList.Count; i++)
            {

                var course = new TraineeCourseResultViewModel();


                course.TraineeName = courseList[i].Trainee.TraName;
                course.CourseName = courseList[i].Course.CrsName;
                course.CourseDegree = courseList[i].CrsResultDegree;
                course.Color = course.CourseDegree > courseList[i].Course.CrsMinDegree ? "green" : "red";

                td.Add(course);
            }

            return View(td);
        }
        public IActionResult ShowCourseResult(int cid)
        {
            var traineeList = db.CrsResult.Where(c => c.CrsId == cid)
                .Include(c => c.Course)
                .Include(t => t.Trainee).ToList();

            if (traineeList == null)
            {
                return NotFound();
            }
            List<TraineeCourseResultViewModel> td = new List<TraineeCourseResultViewModel>();

            for (int i = 0; i < traineeList.Count; i++)
            {

                var course = new TraineeCourseResultViewModel();


                course.TraineeName = traineeList[i].Trainee.TraName;
                course.CourseName = traineeList[i].Course.CrsName;
                course.CourseDegree = traineeList[i].CrsResultDegree;
                course.Color = course.CourseDegree > traineeList[i].Course.CrsMinDegree ? "green" : "red";

                td.Add(course);
            }

            return View(td);
        }
    }
}