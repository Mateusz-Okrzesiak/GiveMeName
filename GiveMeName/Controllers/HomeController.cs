using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveMeName.Models;
using GiveMeName.Helpers;

namespace GiveMeName.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {

            return View(new UserListVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Home(UserListVM model)
        {
            if (ModelState.IsValid)
            {
                string webContent = WebContentHelper.GetContent(model.UrlAddress);
                model.Users = WebContentHelper.GetUserInfo(webContent);
            }

            return View();
        }
    }
}