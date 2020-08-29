using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppScript.Models;
using WebAppScript.Servics;

namespace WebAppScript.Controllers
{
    public class CustomerController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetCustomerList()
        {            
            CustumerServices cus = new CustumerServices();

            var data = cus.getCustumerList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCustomer(CustomerModel model)     
        {
            CustumerServices cus = new CustumerServices();
            //pkopkopk0oko
            cus.InsertCustumer(model);

            return Json(true);
        }

        [HttpGet]
        public JsonResult GetCustomerById(int Id)
        {
            CustumerServices cus = new CustumerServices();
            //pkopkopk0oko
            var model = cus.GetCustomerById(Id);


            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCustomer(CustomerModel model)
        {
            CustumerServices cus = new CustumerServices();
            //pkopkopk0oko
            cus.UpdateCustumer(model);

            return Json(true,JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult DeleteCustomer(int ID)
        {
            CustumerServices cus = new CustumerServices();
            //pkopkopk0oko
            cus.DeleteCustumer(ID);

            return Json(true,JsonRequestBehavior.AllowGet);
        }


    }
}