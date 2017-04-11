namespace WyseOwl.Logic
{
    using System;
    using RestSharp;
    using WyseOwl.Models;

    public class NodeCommunication
    {
        public CalculationsViewModel1.CalculationResult SendFirstCalculation(CalculationsViewModel1.FirstCalculation calc)
        {
            var client = new RestClient("http://wyseowlnode.azurewebsites.net");
            var request = new RestRequest("calc", Method.POST) { RequestFormat = DataFormat.Json };

            //if (calc.StartYear < 1999)
            //{
            //    calc.StartYear = "Before 1999";
            //}

            request.AddBody(new
                                {
                                   dl = calc.Balance,
                                   l = "England",// calc.SelectedAddressCountry, 
                                   c = "United Kingdom",
                                   ys = "2016", //calc.StartYear, 
                                   ye = "2016", //calc.EligibleYear, 
                                   paye = "Yes", 
                                   ge = "10000",//calc.GrossEarnings, 
                                   td = "per year", // calc.SelectedGrossEarningsPer, 
                                   ar = "100", //calc.Repayments, 
                                   curr_ar = "British Pound", //calc.SelectedRepaymentsCurrency, 
                                   td_ar = "per year", // calc.SelectedRepaymentsPer,
                                   age_m = "01", //calc.age_m, 
                                   age_y = "1991", //calc.age_y,
                                   bulk = "500", //calc.bulk, 
                                   curr_bulk = "British Pound", //calc.curr_bulk, 
                                   pg = "Yes", // calc.pg
                                });

            try
            {
                var result = client.Execute(request);
                var noBrackets = result.Content.Substring(1, result.Content.Length - 2);
                noBrackets = noBrackets.Replace(Environment.NewLine, "");
                var splitted = noBrackets.Split('!');

                var a = splitted[0].Remove(0, 4);
                var b = splitted[2].Remove(0, 6);
                var c = splitted[4].Remove(0, 6);
                var d = splitted[5].Remove(0, 6);
                var e = splitted[6].Remove(0, 6);
                var f = splitted[7].Remove(0, 6);
                var g = splitted[3].Remove(0, 6);
                var h = splitted[1].Remove(0, 6);

                return new CalculationsViewModel1.CalculationResult
                           {
                               OutstandingLoan = a,
                               LengthUntillPaidOff = b,
                               YouSave = c,
                               TotalAmountRepayments = d,
                               MonthlyRepayments = e,
                               InterestRate = f,
                               CancelledIn = g,
                               LoanType = h
                           };
            }
            catch (Exception error)
            {
                // Log
            }

            return null;
        }
    }
}