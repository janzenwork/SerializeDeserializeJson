using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class SerializeDeserialize
    {
        static void Main()
        {
            Stock stock = new Stock();

            var symbol = "AMZN";
            var price = 1500.00;
            var date = DateTime.Now;

            //The Main function calls the SerializeJson function with given parameters
            //Then SerializeJson calls DeserializeJson with same parameters

            stock.SerializeJson(symbol, price, date);

        }
    }

    public class Stock
    {
        public string Symbol { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public void SerializeJson(string symbol, double price, DateTime date)
        {
            //This function serializes json objects
            //it creates a Stock object named stock
            //takes the object and serializes it
            //then passes the values to deserialize function

            Stock stock = new Stock();
            stock.Symbol = symbol;
            stock.Price = price;
            stock.Date = date;

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(stock);
            Console.WriteLine("The Json object returned is ");
            Console.Write(jsonString);
            Console.WriteLine();
            DeserializeJson(jsonString, symbol, price, date);
            
        }

        public void DeserializeJson(string DeserializeStock, string symbol, double price, DateTime date)
        {

            //This function accepts values from SerializeJson as parameters
            //it deserializes the json object into a stock object and 
            //displays those values to the user

            Stock deStock = new Stock();
            deStock.Symbol = symbol;
            deStock.Price = price;
            deStock.Date = date;

            var deserializeJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Stock>(DeserializeStock);
            Console.WriteLine("Here is the same stock deserialized");
            Console.WriteLine("The stock symbol is " + deserializeJson.Symbol);
            Console.WriteLine("The stock price is " + deserializeJson.Price);
            Console.WriteLine("The date is " + deserializeJson.Date);

        }
    }
}
