using System.ComponentModel.DataAnnotations;

namespace WyseOwl.Models
{
    public class CalculationsViewModel1
    {
        public class FirstCalculation
        {
            [Required]
            [Display(Name = "Balance")]
            public string Balance { get; set; }

            [Required]
            [Display(Name = "Home Address")]
            public string HomeAddress { get; set; }
        }
    }
}