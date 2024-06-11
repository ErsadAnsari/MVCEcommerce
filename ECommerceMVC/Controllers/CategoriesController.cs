using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index()
        {
            CompanyDBContext dbContext = new CompanyDBContext();
           List<Category> categories= dbContext.Categories.ToList();
            return View(categories);
        }
    }
}