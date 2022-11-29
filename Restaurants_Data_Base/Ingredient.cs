namespace Restaurants_Data_Base
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double CostPerGram { get; set; }
        public double TotalUsing { get; set; } = 0;

        public Ingredient(string name, double costPerGram)
        {
            Name = name;
            CostPerGram = costPerGram;
        }

        public void ShowTotalUsed()
        {
            double totalWeight = Math.Round(TotalUsing / 1000, 3);
            Console.Write($"Total weight of ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" in all meals in every restaurant is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(totalWeight);
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine($" kilos");
        }



        //public void Print()
        //{
        //    Console.WriteLine($"{Name} - {weigth} gr");
        //}


            
    }
}