using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using Vacay.Models;

namespace Vacay.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("User"))
            {
                return View("UserIndex");
            }
            else if (User.IsInRole("Admin"))
            {
                return View("AdminIndex");
            }
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult MyTravelJournal()
        {
            var postsList = _context.JournalPost.ToList();
            var userPosts = new List<JournalPost>();
            foreach(var post in postsList)
            {
                if (post.Username == User.Identity.GetUserName())
                {
                    userPosts.Add(post);
                }
            }
            var viewModel = new TravelJournalViewModels
            {
                Posts = userPosts
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(TravelJournalViewModels model)
        {
            if (ModelState.IsValid)
            {
                var userPost = new JournalPost
                {
                    City = model.City,
                    Location = model.Location,
                    Post = model.Post,
                    Date = DateTime.Today.Date,
                    Username = User.Identity.GetUserName()
                };

                _context.JournalPost.Add(userPost);
                _context.SaveChanges();

                return RedirectToAction("MyTravelJournal", "Home");
            }

            return View();

        }

        public ActionResult ActivitiesNearMe()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PopularPlacesNearMe()
        {
            var postsList = new List<PostAndLikes>();
            var allPosts = _context.JournalPost.ToList();
            var allUpvotes = _context.UserUpvote.ToList();

            foreach(var post in allPosts)
            {
                var journalPost = new PostAndLikes();
                journalPost.Post = post;
                foreach(var upvote in allUpvotes)
                {
                    if(upvote.JournalPostId == post.ID)
                    {
                        journalPost.ListOfUpvotes.Add(upvote);
                    }
                }

                postsList.Add(journalPost);
            }

            var sortedList = postsList.OrderByDescending(m => m.ListOfUpvotes);
            var viewModel = new PopularPlacesViewModel
            {
                Posts = sortedList,
                Zero = 0
            };
            return View(viewModel);
            
        }

        public ActionResult Weather()
        {
            //ViewBag.Message = "Your contact page.";/

            return View();
        }
        public ActionResult UserIndex()
        {
            return View();
        }

        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}