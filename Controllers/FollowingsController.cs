using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BigSchoolProject.DTOs;
using BigSchoolProject.Models;
using BigSchoolProject.ViewModels;
using Microsoft.AspNet.Identity;

namespace BigSchoolProject.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public FollowingsController()
        {

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }

        //public ActionResult Following()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var followings = _dbContext.Followings
        //        .Where(a => a.FollowerId == userId)
        //        .Select(a => a.Followee)
        //        .ToList();

        //    var viewModel = new FollowingViewModel
        //    {
        //        Followings = followings,
        //        ShowAction = User.Identity.IsAuthenticated
        //    };

        //    return View(viewModel);
        //}

        [System.Web.Http.HttpDelete]
        public IHttpActionResult UnFollow(string followeeId, string followerId)
        {
            var follow = _dbContext.Followings
                .Where(x => x.FolloweeId == followeeId && x.FollowerId == followerId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            _dbContext.Followings.Remove(follow);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}