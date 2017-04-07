using System.ComponentModel.DataAnnotations;

namespace WyseOwl.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CalculationsViewModel1
    {
        public class FirstCalculation
        {
            [Required]
            [Display(Name = "Balance")]
            public string Balance { get; set; }

            public IEnumerable<SelectListItem> AddressCountry { get; set; }

            [Display(Name = "Country of origin")]
            public string SelectedAddressCuntry { get; set; }

            [Display(Name = "Beginning year")]
            [Range(1990, 2017, ErrorMessage = "Please select between 1990 and 2017")]
            public int StartYear { get; set; }

            [Display(Name = "Eligible year")]
            [Range(1990, 2017, ErrorMessage = "Please select between 1990 and 2017")]
            public int EligibleYear { get; set; }

            [Display(Name = "Paye")]
            public bool Paye { get; set; }


            public CalculationResult CalculationResult { get; set; }
        }

        public class CalculationResult
        {
            [Display(Name = "Result1")]
            public string Result1 { get; set; }
        }
    }
}