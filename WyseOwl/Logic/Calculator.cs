using System.Threading.Tasks;

namespace WyseOwl.Logic
{
    using EdgeJs;

    public class Calculator
    {
        const string JSCalculate = @"return function(data, callback) {                                  
                                         callback(null, 'I am sayin ');
                                    }";

        public static async Task<object> CAllme()
        {
            var func = Edge.Func(JSCalculate);
            var a = await func("mee");
            return a;
        }

        //public void Calculate()
    }

}