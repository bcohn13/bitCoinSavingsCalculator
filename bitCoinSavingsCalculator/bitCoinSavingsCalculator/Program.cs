using System;
using System.Diagnostics;
using System.Collections;

namespace bitCoinSavingsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Ben");
            /*Console.WriteLine(user.money);*/
            string[] urls ={"" +
                   "https://www.ebay.com/itm/362339555576?epid=2255302434&_trkparms=ispr%3D1&hash=item545d1ed8f8:g:ndEAAOSwXzVgaMdD&amdata=enc%3AAQAGAAAA4I9tpipLUz0h5xr7wOh%2BxuvooAEKh54CVuviSs5ivG3rODceZfrUhq0IBWPFLaPwG%2FWmXETBJuVt7AYDyr1pSfzAyHj2oVi3bsWSjyL0Wn1D0wAbRpDd1usQtFCnvwzuwM6pggLEmxSalY97uAHWTWfknKIAen7RfhG3mtTtxX3c9TM%2FcmfR81PrDDWzpWqRLl3I%2Bq1Bbfnw1%2Fs9Y6Ewv%2By4%2FDlBVRo7A9GS%2BMn1a9wduQm0QjEwmWDW8cCT8CM1Sb3v%2FFhkGJr03%2FOrIMw6aDzrCUrZWDyx2FLcBorr913o%7Ctkp%3ABFBM4qiSgpRg",
                   "https://www.ebay.com/itm/151239684662?_trkparms=ispr%3D1&hash=item2336967236:g:GGEAAOSw~uhUq-mq&amdata=enc%3AAQAGAAAA4Bc%2BaztazwNBxktEwjgWg785muPTdGrbif6aET6Ia%2B3fdsf%2BpO0OJ2p5dnFRsQWoVBKCUm4R4CyQau1fqfwFF74shwrycWSszTBdQKtaSDsxfLQbn7wynyghYmvlkXjWnZZi7%2BT6%2FYSJ8FRY89oIYlOUEzF2fzZhw8ILP4uejhOhN%2FTGxyKwJiOeiX9nXNMztobNmd6GrYrHe9bbUVbvqtRjh9Uhx2ZEK15bWE57sCaXWyvjxx8Cahtmh5OutdHD9EdRWLwvlWvNnVj6IIIbmPeQOwqlNzZayblUglfVGylt%7Ctkp%3ABFBM5Juci5Rg",
                   "https://www.ebay.com/itm/143994319831?_trkparms=ispr%3D5&hash=item2186baf3d7:g:oJEAAOSw9NRgZS7V&amdata=enc%3AAQAGAAAAwCqdTUQTDxvmE0mxK6brGyJyZugSMeb2GhY8bdk7mE4IxhuOla17fC3R65ddNkmDEzXkXyprhrRH2CWLMlUSEFqkNEnRLhZT9Z5l6K%2BL00dELtiuhe6IHpd7Iy%2Bx%2FPslMwF735pI212jfCyX2WC4ijRKSbtXJ48GaNyuRgGDTsyVgPDlwfieQL8MMONGDuKOJb%2BFiNyRmwBUWd2%2F8N2BxRcVvsTibY%2F9IQxv8dGgoN6X7%2FRCiCHwG%2BvvYXHy1Cag0g%3D%3D%7Ctkp%3ABlBMUIKnrouUYA" };

            foreach (var url in urls) {
                /*Got code from https://stackoverflow.com/questions/22642975/execute-python-functions-return-results-to-c-sharp*/
                var start = new ProcessStartInfo();
                start.FileName = "C:\\Users\\bcohn\\Anaconda3\\python.exe";
                start.Arguments = " C:\\Users\\bcohn\\source\\repos\\bitCoinSavingsCalculator\\bitCoinSavingsCalculator\\product_data_web_scrapping.py "+url+"; ";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                var process = Process.Start(start);
                var reader = process.StandardOutput;
                var output = reader.ReadToEnd();
                var outputVariables = output.Split("LINEBREAK");
                var name = outputVariables[0];
                var price = Double.Parse(outputVariables[1]);
                var date = outputVariables[2];
                var purchase = new Purchase(name, price, date);
                user.purchases.Add(purchase);
                
            }
            user.getBitCoinInDollars(.025);
            Console.WriteLine(user.calculateSavings());
        }
    }
}
