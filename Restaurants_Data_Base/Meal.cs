namespace Restaurants_Data_Base
{
    public class Meal
    {
        public string Name { get; set; }
        public Dictionary<Ingredient, double> Ingredients = new Dictionary<Ingredient, double>();
        public double MealPrice { get; set; }

        public Meal(string name, Dictionary<Ingredient, double> ingredients)
        {
            Name = name;
            Ingredients = ingredients;

            MealPrice = 0;
            foreach (var price in ingredients.Values)
            {
                MealPrice += price;
            }
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

            double totalPrice = 0;
            double totalWeight = 0;

            foreach (var ingredient in Ingredients)
            {
                var cost = ingredient.Key.CostPerGram * ingredient.Value / 100;
                cost = Math.Round(cost, 2);
                Console.WriteLine($"{ingredient.Key.Name} - {ingredient.Value} grams - {cost} dollars");
                totalPrice += cost;
                totalWeight += ingredient.Value;
            }
            Console.WriteLine();
            Console.WriteLine($"Total price - {Math.Round(totalPrice, 2)} dollars");
            Console.WriteLine($"Total weight - {totalWeight} grams");
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }



    }
}
