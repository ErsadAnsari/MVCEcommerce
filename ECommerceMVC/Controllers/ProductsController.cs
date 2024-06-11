using ECommerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(int PageNo=1, string SortColumn = "ProductName",string IconClass= "fa-sort-asc", string search="")
        {
            CompanyDBContext DbContext = new CompanyDBContext();
            List<Product> ProductList = DbContext.Products.Where(val => val.ProductName.Contains(search)).ToList();
            ViewBag.IconClass = IconClass;
            ViewBag.SortColumn = SortColumn;
            if(ViewBag.SortColumn=="ProductName")
            {
                if(IconClass== "fa-sort-asc")
                {
                    ProductList = ProductList.OrderBy(p => p.ProductName).ToList();
                }
               
                 else
                {
                    ProductList = ProductList.OrderByDescending(p => p.ProductName).ToList();
                }
                
            }
            if (ViewBag.SortColumn == "DOP")
            {
                if (IconClass == "fa-sort-asc")
                {
                    ProductList = ProductList.OrderBy(p => p.DOP).ToList();
                }

                else
                {
                    ProductList = ProductList.OrderByDescending(p => p.DOP).ToList();
                }

            }
            ViewData["Search"] = search;
            // paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling( Convert.ToDecimal(ProductList.Count) / Convert.ToDecimal(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            ProductList = ProductList.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
           
            return View(ProductList);
        }
        public ActionResult Details(long Id)
        {
            CompanyDBContext DbContext = new CompanyDBContext();
            Product P = new Product();
            P = DbContext.Products.Where(e => e.ProductID == Id).FirstOrDefault();
            return View(P);
        }
        public ActionResult Create()
        {
            CompanyDBContext DbContext = new CompanyDBContext();
            ViewBag.CategoryList = DbContext.Categories.ToList();
            ViewData["BrandList"] = DbContext.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product P)
        {
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                P.Photo = base64String;
            }
            CompanyDBContext DbContext = new CompanyDBContext();
            DbContext.Products.Add(P);
            DbContext.SaveChanges();
            return RedirectToAction("index","products");
        }
        public ActionResult Edit(long Id)
        {
            CompanyDBContext DbContext = new CompanyDBContext();
            Product P = DbContext.Products.Where(p => p.ProductID == Id).FirstOrDefault();
            ViewBag.CategoryList = DbContext.Categories.ToList();
            ViewData["BrandList"] = DbContext.Brands.ToList();
            return View(P);
        }
        [HttpPost]
        public ActionResult Edit(Product PId)
        {
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                PId.Photo = base64String;
            }
            CompanyDBContext dbContext = new CompanyDBContext();
            Product P = dbContext.Products.Where(p => p.ProductID == PId.ProductID).FirstOrDefault();
            P.ProductName = PId.ProductName;
            P.Price = PId.Price;
            P.DOP = PId.DOP;
            P.CategoryID = PId.CategoryID;
            P.BrandID = PId.BrandID;
            P.AvailabilityStatus = PId.AvailabilityStatus;
            P.Active = PId.Active;
            if(!string.IsNullOrEmpty(PId.Photo))
            {
                P.Photo = PId.Photo;
            }
            
            dbContext.SaveChanges();
            return RedirectToAction("index","products");
        }

        public ActionResult Delete(long Id)
        {
            CompanyDBContext dbContext = new CompanyDBContext();
            Product P = dbContext.Products.Where(p => p.ProductID == Id).FirstOrDefault();

            return View(P);
        }
        [HttpPost]
        public ActionResult Delete(Product Prod)
        {
            CompanyDBContext dbContext = new CompanyDBContext();
            Product P = dbContext.Products.Where(p => p.ProductID == Prod.ProductID).FirstOrDefault();
            dbContext.Products.Remove(P);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}
