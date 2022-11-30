namespace Restaurants_Data_Base.Place
{
    public class Meal
    {
        public string Name { get; set; }
        /// <summary>
        /// Dictionary for saving ingredient and its weight in that meal
        /// </summary>
        public Dictionary<Ingredients.Ingredient, double> Ingredients = new Dictionary<Ingredients.Ingredient, double>();
        public double MealPrice { get; set; }
        public double MealWeight { get; set; }

        public Meal(string name, Dictionary<Ingredients.Ingredient, double> ingredients)
        {
            Name = name;
            Ingredients = ingredients;

            MealPrice = 0;
            foreach (var option in ingredients)
            {
                MealWeight += option.Value;
                MealPrice += option.Value * option.Key.CostPerGram / 100;
                option.Key.TotalUsing += option.Value;
            }
            MealWeight = Math.Round(MealWeight, 2);
            MealPrice = Math.Round(MealPrice, 2);
        }

        /// <summary>
        /// Shows all ingredients with weight and total price in that meal and meal weight and price
        /// </summary>
        public void ShowIngredientsAndPrice()
        {
            Console.Clear();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{Name}:");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (var ingredient in Ingredients)
            {
                double cost = ingredient.Key.CostPerGram * ingredient.Value * 0.01;
                Console.WriteLine($"{ingredient.Key.Name} - {ingredient.Value} grams - {cost} dollars");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Total price - {MealPrice} dollars");
            Console.WriteLine($"Total weight - {MealWeight} grams");
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
