namespace WyseOwl.Controllers
{
    using System.Collections.Generic;
    using System.Threading;

    using WyseOwl.Models;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalculationsViewModel1.FirstCalculation
                            {
                                AddressCountry =
                                    this.GetSelectListItems(
                                        this.GetAllAddressCountries())
                            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CalculationsViewModel1.FirstCalculation calcultionInputs)
        {
            calcultionInputs.AddressCountry = GetSelectListItems(GetAllAddressCountries());
            if (!ModelState.IsValid)
            {
                return View("Index", calcultionInputs);
            }
            Thread.Sleep(2000);
            calcultionInputs.CalculationResult = new CalculationsViewModel1.CalculationResult { Result1 = "1234" };
            return this.View("Index", calcultionInputs );
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

        private IEnumerable<string> GetAllAddressCountries()
        {
            return new List<string>
            {
                "England",
                "North Ireland",
                "Wales",
                "Scotland"
            };
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}