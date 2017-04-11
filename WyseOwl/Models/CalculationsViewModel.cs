using System.ComponentModel.DataAnnotations;

namespace WyseOwl.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    public class CalculationsViewModel1
    {
        public class FirstCalculation
        {
            // [Required]
            [Display(Name = "Balance")]
            [JsonProperty(PropertyName = "dl")]
            public string Balance { get; set; }

            // [Required]
            [Display(Name = "Country of origin")]
            [JsonProperty(PropertyName = "l")]
            public string SelectedAddressCountry { get; set; }

            // [Required]
            [Display(Name = "Country of work")]
            [JsonProperty(PropertyName = "c")] 
            public string SelectedWorkCountry { get; set; }

            [Display(Name = "Beginning year")]
            [Range(1990, 2017, ErrorMessage = "Please select between 1990 and 2017")]
            [JsonProperty(PropertyName = "ys")]
            public int StartYear { get; set; }

            [Display(Name = "Eligible year")]
            [Range(1990, 2017, ErrorMessage = "Please select between 1990 and 2017")]
            [JsonProperty(PropertyName = "ye")]
            public int EligibleYear { get; set; }

            // [Required]
            [Display(Name = "Paye")]
            [JsonProperty(PropertyName = "paye")]
            public bool Paye { get; set; }

            // [Required]
            [Display(Name = "Gross earnings")]
            [JsonProperty(PropertyName = "ge")]
            public int GrossEarnings { get; set; }

            // [Required]
            [Display(Name = "Gross earnings per")]
            [JsonProperty(PropertyName = "td")]
            public string SelectedGrossEarningsPer { get; set; }

            // [Required]
            [Display(Name = "Repayments")]
            [JsonProperty(PropertyName = "ar")]
            public int Repayments { get; set; }

            // [Required]
            [JsonProperty(PropertyName = "curr_ar")]
            public string SelectedRepaymentsCurrency { get; set; }

            // [Required]
            [JsonProperty(PropertyName = "td_ar")]
            public string SelectedRepaymentsPer { get; set; }


            public string age_m { get; set; }

            public string age_y { get; set; }

            public string bulk { get; set; }

            public string curr_bulk { get; set; }

            [Display(Name = "Post graduate loan?")]
            public bool PostGraduateLoan { get; set; }

            public IEnumerable<SelectListItem> AddressCountry { get; set; }

            public IEnumerable<SelectListItem> WorkCountry { get; set; }

            public IEnumerable<SelectListItem> PerTime { get; set; }

            public IEnumerable<SelectListItem> Currency { get; set; }




            public CalculationResult CalculationResult { get; set; }
        }

        public class CalculationResult
        {
            public string OutstandingLoan { get; set; }
            public string LengthUntillPaidOff { get; set; }
            public string YouSave { get; set; }
            public string TotalAmountRepayments { get; set; }
            public string MonthlyRepayments { get; set; }
            public string InterestRate { get; set; }
            public string CancelledIn { get; set; }
            public string LoanType { get; set; }

            public string PrevResultGef { get; set; }
            public string PrevResultTdn { get; set; }
            public string PrevResultLet_p1 { get; set; }
            public string PrevResultLet_p2 { get; set; }
            public string PrevResultUet { get; set; }
            public string PrevResultRl { get; set; }
            public string PrevResultCancel { get; set; }

            public string PrevResultJ1 { get; set; }
            public string PrevResultLet_pl { get; set; }

            [Display(Name = "Voluntary repayment")]
            public string RecalcRepayment { get; set; }

            public string RecalcRepaymentCurrency { get; set; }

            public string RecalcRepaymentPer { get; set; }

            [Display(Name = "One time repayment")]
            public string RecalcOneTime { get; set; }

            public string RecalcOneTimeCurrency { get; set; }
        }
    }
}