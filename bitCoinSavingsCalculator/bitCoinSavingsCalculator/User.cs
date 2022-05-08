using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;


namespace bitCoinSavingsCalculator
{
    class User
     
    {
        public string name { get; set; }
        public List<Purchase> purchases { get; set; }
        public Double money { get; set; }
        public User(string Name)
        {
            name = Name;
            purchases=new List<Purchase>();
            money=0;
        }

        public void getBitCoinInDollars(Double bitCoins) {

            var start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\bcohn\\Anaconda3\\python.exe";
            start.Arguments = " C:\\Users\\bcohn\\source\\repos\\bitCoinSavingsCalculator\\bitCoinSavingsCalculator\\bitcoin_data_web_scrapping.py ";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            var process = Process.Start(start);
            var reader = process.StandardOutput;
            var output = reader.ReadToEnd();
            Console.WriteLine(output);
            var bitCoinPrice = Double.Parse(output);
            var bitCoinMoneyinUsDollars = bitCoins*bitCoinPrice;
            money+=bitCoinMoneyinUsDollars;

        }

        public Double calculateSavings()
        {
            var purchaseTotal = 0.0;
            foreach (var purchase in purchases)
            {
                purchaseTotal+=purchase.price;
            }
            return money-purchaseTotal;
        }
        
    }
}
