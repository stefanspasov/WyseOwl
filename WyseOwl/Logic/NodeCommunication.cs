namespace WyseOwl.Logic
{
    using System;
    using RestSharp;
    using WyseOwl.Models;

    public class NodeCommunication
    {
        public CalculationsViewModel1.CalculationResult SendFirstCalculation(CalculationsViewModel1.FirstCalculation calc)
        {
            var client = new RestClient("http://localhost:8081/");
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

                var u = splitted[8].Remove(0, 6);
                var x = splitted[9].Remove(0, 6);
                var y = splitted[10].Remove(0, 6);
                var z = splitted[11].Remove(0, 6);

                var zz = splitted[12].Remove(0, 6);
                var zzz = splitted[13].Remove(0, 6);
                var zzzz = splitted[14].Remove(0, 6);

                var yy = splitted[15].Remove(0, 6);
                var yyy = splitted[16].Remove(0, 5);

                yyy = yyy.Remove(yyy.Length - 1);

                return new CalculationsViewModel1.CalculationResult
                           {
                               OutstandingLoan = a,
                               LengthUntillPaidOff = b,
                               YouSave = c,
                               TotalAmountRepayments = d,
                               MonthlyRepayments = e,
                               InterestRate = f,
                               CancelledIn = g,
                               LoanType = h,
                               PrevResultGef = u,
                               PrevResultTdn = x,
                               PrevResultLet_p1 = y,
                               PrevResultLet_p2 = z, 
                               PrevResultUet = zz, 
                               PrevResultRl = zzz, 
                               PrevResultCancel = zzzz, PrevResultLet_pl = yy, PrevResultJ1 = yyy
                           };
            }
            catch (Exception error)
            {
                // Log
            }

            return null;
        }

        public CalculationsViewModel1.CalculationResult SendSecondCalculation(CalculationsViewModel1.FirstCalculation calc)
        {
            var client = new RestClient("http://wyseowlnode.azurewebsites.net");
            var request = new RestRequest("recalc", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(new
            {
                arc = calc.CalculationResult.RecalcRepayment, 
                td_arc = calc.CalculationResult.RecalcRepaymentPer, 
                curr_arc = calc.CalculationResult.RecalcRepaymentCurrency,
                bulk_ar = calc.CalculationResult.RecalcOneTime,
                curr_bulk_ar = calc.CalculationResult.RecalcOneTimeCurrency, 
                gef = calc.CalculationResult.PrevResultGef, 
                tdn = calc.CalculationResult.PrevResultTdn,
                let_p1 = calc.CalculationResult.PrevResultLet_p1,
                let_p2 = calc.CalculationResult.PrevResultLet_p2,
                loantype = calc.CalculationResult.LoanType, 
                uet = calc.CalculationResult.PrevResultUet,
                rl = calc.CalculationResult.PrevResultRl,
                cancelledl = calc.CalculationResult.PrevResultCancel, 
                j1 = calc.CalculationResult.PrevResultJ1, 
                let_pl = calc.CalculationResult.PrevResultLet_pl
            });

            try
            {
                var result = client.Execute(request);
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
 }