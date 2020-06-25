using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab6.DAL;
using Lab6.Models;
using Lab6.Models.ViewModels;

namespace Lab6.Controllers
{
    public class ProductController : Controller
    {
        private WWIContext db = new WWIContext(); 
        // GET: Product

            [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); 
            }
            //Product product = db.Products.Find(id);


            
            //Stockitem query
            var my =(from c in db.StockItems where c.StockItemName == name select c.StockItemID).FirstOrDefault();
            StockItem stockitem = db.StockItems.Find((int)my);
            
            //Supplier query
           var my2 = (from c in db.StockItems where c.StockItemName == name select c.SupplierID).FirstOrDefault();
            Supplier supplier = db.Suppliers.Find((int)my2);
            
            //Person Query
            var my3 = (from s in db.StockItems
                       join sp in db.Suppliers
                       on s.SupplierID equals sp.SupplierID
                       where s.StockItemName == name
                       join p in db.People
                       on sp.PrimaryContactPersonID equals p.PersonID
                       select p.PersonID).FirstOrDefault();

            Person person = db.People.Find((int)my3);

            //InvoiceLine query
            var my4 = (from c in db.StockItems 
                       join i in db.InvoiceLines
                       on c.StockItemID equals i.StockItemID
                       where c.StockItemName == name
                       select i.StockItemID).FirstOrDefault();

            InvoiceLine invoiceLine = db.InvoiceLines.Find((int)my4); 




            ProductDetailsViewModel viewmodel = new ProductDetailsViewModel(stockitem, supplier, person, invoiceLine);
            return View(viewmodel);
        }
        
        [HttpGet]
        public ActionResult Search(string item)
        {
           
            return View(db.StockItems.Where(s => s.StockItemName.Contains(item)).ToList());
        }
        [HttpPost]
        public ActionResult Search()
        {
            
            

            return View(); 
        }
    }
    
}