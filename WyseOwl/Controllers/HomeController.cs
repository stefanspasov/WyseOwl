namespace WyseOwl.Controllers
{
    using System.Collections.Generic;
    using System.Threading;
    using WyseOwl.Models;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    using WyseOwl.Logic;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalculationsViewModel1.FirstCalculation
                            {
                                AddressCountry =
                                    this.GetSelectListItems(
                                        this.GetAllAddressCountries()), 
                                WorkCountry = this.GetSelectListItems(this.GetAllWorkCountries()),
                                PerTime = this.GetSelectListItems(this.GetAllPerTime()),
                                Currency = this.GetSelectListItems(this.GetAllCurrencies()),
                                EligibleYear = 2000, 
                                StartYear = 2000,
                                CalculationResult = new CalculationsViewModel1.CalculationResult()
                            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CalculationsViewModel1.FirstCalculation calcultionInputs)
        {
            calcultionInputs.AddressCountry = GetSelectListItems(GetAllAddressCountries());
            calcultionInputs.WorkCountry = GetSelectListItems(GetAllWorkCountries());
            calcultionInputs.PerTime = GetSelectListItems(GetAllPerTime());
            calcultionInputs.Currency = GetSelectListItems(GetAllCurrencies());
            if (!ModelState.IsValid)
            {
                return View("Index", calcultionInputs);
            }


            calcultionInputs.age_m = "01";
            calcultionInputs.age_y = "1991";
            calcultionInputs.bulk = "500";
            calcultionInputs.curr_bulk = "British Pound";
            calcultionInputs.pg = "Yes";

            var client = new NodeCommunication();
            client.SendFirstCalculation(calcultionInputs);
            calcultionInputs.CalculationResult = new CalculationsViewModel1.CalculationResult { Result1 = "1234" };
            return this.Json(new { success = true, result = calcultionInputs.CalculationResult });
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

        private IEnumerable<string> GetAllWorkCountries()
        {
            return new List<string>
            {
                "England",
                "North Ireland",
                "Wales",
                "Scotland"
            };
        }

        private IEnumerable<string> GetAllPerTime()
        {
            return new List<string>
            {
                "per year", "per month", "per week"
            };
        }

        private IEnumerable<string> GetAllCurrencies()
        {
            return new List<string>
            {
                "British Pound"
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