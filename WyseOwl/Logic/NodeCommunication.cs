namespace WyseOwl.Logic
{
    using System;
    using RestSharp;
    using WyseOwl.Models;

    public class NodeCommunication
    {
        public void SendFirstCalculation(CalculationsViewModel1.FirstCalculation calc)
        {
            var client = new RestClient("http://wyseowlnode.azurewebsites.net");
            var request = new RestRequest("calc", Method.POST);
            request.RequestFormat = DataFormat.Json;
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
                var a = client.Execute(request);
        
            }
            catch (Exception error)
            {
                // Log
            }
        }
    }
}