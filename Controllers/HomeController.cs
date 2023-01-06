using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oelkhiz.Controllers
{
    public class HomeController : Controller
    {
        khizdbEntities _context = new khizdbEntities();
        public ActionResult Index()
        {
            var listofData = _context.user1.ToList();
            return View(listofData);

        }


        [HttpGet]  
	 public ActionResult Create()
	 {  
	     return View();  
	 }


        [HttpPost]  
	 public ActionResult Create(user1 model)
	 {              
	     _context.user1.Add(model);  
	     _context.SaveChanges();  
	     ViewBag.Message = "Data Insert Successfully";  
	     return View();
        }
        	[HttpGet]  
        public ActionResult Edit(int id)
	{               
	    var data = _context.user1.Where(x => x.ID == id).FirstOrDefault();  
	    return View(data);  
	}  
	[HttpPost]  
	public ActionResult Edit(user1 Model)
	{  
	    var data = _context.user1.Where(x => x.ID == Model.ID).FirstOrDefault();  
	    if (data != null)  
	    {  
	        data.Name = Model.Name;  
            data.Salary = Model.Salary;  
	        data.Social_Link = Model.Social_Link;
				data.Age = Model.Age;
				data.Gender = Model.Gender;
				data.Username = Model.Username;
				data.Password = Model.Password;
	        _context.SaveChanges();  
	    }  
	  
	    return RedirectToAction("index");
		}  
		public ActionResult Details(int id)
	{  
	    var data = _context.user1.Where(x => x.ID == id).FirstOrDefault();  
	    return View(data);
		}
			public ActionResult Delete(int id)
	{  
	    var data = _context.user1.Where(x => x.ID == id).FirstOrDefault();  
	    _context.user1.Remove(data);  
	    _context.SaveChanges();  
       ViewBag.Messsage = "Record Delete Successfully";  
	    return RedirectToAction("index");  
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