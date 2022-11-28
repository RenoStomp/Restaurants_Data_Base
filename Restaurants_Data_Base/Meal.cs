namespace Restaurants_Data_Base
{
    public class Meal
    {
        public string Name { get; set; }
        public Dictionary<Ingredient, double> Ingredients = new Dictionary<Ingredient, double>();
        public double MealPrice { get; set; }
        public double MealWeight { get; set; }

        public Meal(string name, Dictionary<Ingredient, double> ingredients)
        {
            Name = name;
            Ingredients = ingredients;

            MealPrice = 0;
            foreach (var option in ingredients)
            {
                MealWeight += option.Value;
                MealPrice += option.Value * option.Key.CostPerGram / 100;
            }
            MealWeight = Math.Round(MealWeight, 2);
            MealPrice = Math.Round(MealPrice, 2);
        }

        public void ShowIngredientsPricesPerGram()
        {
            Console.WriteLine($"{Name}:");

            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Key.Name} - {ingredient.Key.CostPerGram} cents per gram"); ;
            }
        }
        public void ShowIngredientsPrices()
        {
            Console.WriteLine($"{Name}:");
            Console.WriteLine();

            foreach (var ingredient in Ingredients)
            {
                double cost = ingredient.Key.CostPerGram * 0.01;
                Console.WriteLine($"{ingredient.Key.Name} - {ingredient.Value} grams - {cost} dollars");
            }
            Console.WriteLine();
            Console.WriteLine($"Total price - {MealPrice} dollars");
            Console.WriteLine($"Total weight - {MealWeight} grams");
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }



    }
}
