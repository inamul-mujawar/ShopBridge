using ShopBridge.DAL;
using ShopBridge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class AdminController : Controller
    {
        AdminDal adminDal = new AdminDal();
        // GET: Admin
        public ActionResult Home()
        {
            List<Item> listOfItems = adminDal.GetListOfItems();
            return View(listOfItems);
        }

        [HttpGet]
        public JsonResult GetListOfItems(int itemId)
        {
            return Json(adminDal.GetListOfItems().Where(x => x.ItemId == itemId).SingleOrDefault(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddItem(Item itemObj)
        {
            DBResponseModel resp = new DBResponseModel();
            resp.responseMsg = adminDal.InsertItem(itemObj) > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateItem(Item updateItemObj)
        {
            DBResponseModel resp = new DBResponseModel();
            resp.responseMsg = adminDal.UpdateItem(updateItemObj) > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItem(int itemId)
        {
            DBResponseModel resp = new DBResponseModel();
            resp.responseMsg = adminDal.DeleteItem(itemId) > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}