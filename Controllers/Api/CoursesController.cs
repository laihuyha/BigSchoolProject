using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web.Http;
using BigSchoolProject.Models;
using Microsoft.AspNet.Identity;

namespace BigSchoolProject.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _DbContext { get; set; }

        public CoursesController()
        {
            _DbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _DbContext.Courses.Single(c => c.id == id && c.LectureID == userId);
            if (course.isCanceled)
                return NotFound();
            course.isCanceled = true;
            _DbContext.SaveChanges();
            return Ok();
        }
    }
}
