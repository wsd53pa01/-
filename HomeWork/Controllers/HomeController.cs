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
        Random rnd = new Random();
        public int RandomMoney()
        {
          int money = rnd.Next(1000, 10000);
            return money;
        }
        public DateTime RandomDay()
        {
            
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        public ActionResult Index()
        {


            return View();
        }
        public ActionResult Table()
        {

            var table = new List<TableModels>();
            for (var i = 0; i < 201; i++)
            {
               
             
                var date = RandomDay();
               var   money = RandomMoney();
                table.Add(new TableModels { Sharp = i.ToString(), Category = "支出", Date = date, Money = money });
            }


            return View(table);
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