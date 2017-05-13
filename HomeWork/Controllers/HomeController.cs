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
        SkillTreeModel db = new SkillTreeModel();
        public ActionResult Index()
        {


            return View();
        }
        // GET: AccountBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountBooks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                db.AccountBook.Add(accountBook);
                db.SaveChanges();
            }

            return View(accountBook);
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

          
            var table = new List<TableModels>();
            foreach (var item in db.AccountBook)
            {
                table.Add
                    (
                        new TableModels
                        {
                            Sharp = item.Id,
                            Category = item.Categoryyy == 1 ?    "支出"  : "收入",
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