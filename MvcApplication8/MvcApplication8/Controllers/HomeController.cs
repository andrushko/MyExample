using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcApplicationAdmins.Controllers
{
    public class HomeController : Controller
    {
        _Data.UserCrud uc = new _Data.UserCrud();

        public ActionResult Index()
        {
            ViewBag.Users = uc.View();
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id, int IdRole, int IdStatus)
        {
            return View();
        }

        [HttpPost, ActionName("EditUser")]
        public ActionResult EditUser(int id, int IdRole, int IdStatus, FormCollection collection)
        {
            List<Models.User> t = uc.View();
            try
            {
                uc.ChangeRole(id, IdRole);
                uc.ChangeStatus(id, IdStatus);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            List<Models.User> t = uc.View();
            var del = (from c in t where c.id == id select c).First();
            return View(del);
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            List<Models.User> t = uc.View();
            var del = (from c in t where c.id == id select c).First();
            try
            {
                uc.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
