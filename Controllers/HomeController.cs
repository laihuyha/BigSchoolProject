using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchoolProject.Models;
using System.Data.Entity;
using BigSchoolProject.ViewModels;

namespace BigSchoolProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public HomeController()
        {

        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include(c=> c.Lecture)
                .Include(c=>c.Category)
                .Where(c => c.datetime > DateTime.Now);
            var viewModel = new CourseViewModel()
            {
                UpcommingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}