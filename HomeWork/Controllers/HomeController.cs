using HomeWork.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
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
        public ActionResult Table()
        {

            var db = new SkillTreeModel();
            var table = new List<TableModels>();
            foreach (var item in db.AccountBook)
            {
                table.Add
                    (
                        new TableModels
                        {
                            Sharp = item.Id,
                            Category = item.Categoryyy == 1 ? "支出" : "收入",
                            Date = item.Dateee,
                            Money = item.Amounttt,
                            Remark = item.Remarkkk.Length > 6 ? item.Remarkkk.Substring(0, 6) : item.Remarkkk
                        }
                    );
            }

            return View(table);
        }
    }
}