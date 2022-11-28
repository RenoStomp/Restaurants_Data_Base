namespace Restaurants_Data_Base
{
    public class Meal
    {
        public string Name { get; set; }
        public Dictionary<Ingredient, double> ingredients = new Dictionary<Ingredient, double>();
        public double Price { get; set; }

        public Meal(string name, Dictionary<Ingredient, double> ingredients)
        {
            Name = name;
            this.ingredients = ingredients;

            Price = 0;
            foreach (var price in ingredients.Values)
            {
                Price += price;
            }
        }

        public void ShowIngredientsPricesPerGram()
        {
            Console.WriteLine($"{Name}:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Key.Name} - {ingredient.Key.CostPerGram} cents per gram"); ;
            }
        }
        public void ShowIngredientsPrices()
        {
            Console.WriteLine($"{Name}:");

            foreach (var ingredient in ingredients)
            {
                var cost = ingredient.Key.CostPerGram * ingredient.Value / 100;
                cost = Math.Round(cost, 2);
                Console.WriteLine($"{ingredient.Key.Name} - {cost} dollars"); ;
            }
        }



    }
}
