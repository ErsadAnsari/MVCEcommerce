using ECommerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceMVC.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDBContext dbContext = new CompanyDBContext();
            List<Brand> Brandlist = dbContext.Brands.ToList();
            return View(Brandlist);
        }
    }
}