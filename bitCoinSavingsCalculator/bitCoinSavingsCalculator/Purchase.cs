using System;
using System.Collections.Generic;
using System.Text;

namespace bitCoinSavingsCalculator
{
    class Purchase
    {
        public string name { get; set; }
        public double price { get; set; }
        public string date { get; set; }
        public Purchase(string nameParam, double priceParam, string dateParam)
        {
            name=nameParam;
            price=priceParam;
            date=dateParam;
        }
    }
}
                





    

