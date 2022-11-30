namespace Restaurants_Data_Base.Ingredients
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double CostPerGram { get; set; }
        public double TotalUsing { get; set; } = 0;
        public Kind TypeOfIngredient { get; set; }

        public Ingredient(string name, double costPerGram, Kind typeOfIngredient)
        {
            Name = name;
            CostPerGram = costPerGram;
            TypeOfIngredient = typeOfIngredient;
        }

        /// <summary>
        /// Presenting total sum of that ingredient in all meals in all restaurants for each meal
        /// </summary>
        public void ShowTotalUsed()
        {
            double totalWeight = Math.Round(TotalUsing / 1000, 3);
            Console.Write($"Total weight of ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Name);
            Console.ResetColor();
            Console.Write($" in all meals in every restaurant is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(totalWeight);
            Console.ResetColor();
            Console.WriteLine($" kilos");
        }

        /// <summary>
        /// Kind of ingredient
        /// </summary>
        public enum Kind
        {
            Meat,
            Vegetable,
            Spice,
            Fruit,
            Sauce,
            Unknown
        }
    }
}