using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigSchoolProject.Models;

namespace BigSchoolProject.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followings { get; set; }
        public bool ShowAction { get; set; }
    }
}