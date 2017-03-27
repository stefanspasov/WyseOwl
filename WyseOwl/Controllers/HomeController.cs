using System.Web.Mvc;

namespace WyseOwl.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EdgeJs;

    using WyseOwl.Logic;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var func = Edge.Func(@"
                return function (data, callback) {
                callback(null, 'Node.js welcomes ' + data);
            }");
                var a = func(".NET").Result;
                return this.View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                return this.View();
            }
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