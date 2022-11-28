namespace Restaurants_Data_Base
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ChefsName { get; set; }
        public Dictionary<Meal, double> Meals { get; set; }


        public Restaurant(string name, string chefsName, List<Meal> meals)
        {
            Name = name;
            ChefsName = chefsName;
            Meals = new Dictionary<Meal, double>();
            foreach(Meal meal in meals)
            {
                double mealPrice = Math.Round(meal.MealPrice * 1.2, 2);
                Meals.Add(meal, mealPrice);
            }
        }

        public void Print()
        {
            Console.WriteLine(Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine();
            foreach(var meal in Meals)
            {
                meal.Key.ShowIngredientsPrices();
                Console.WriteLine($"{meal.Key.Name}'s sell price - {meal.Value} dollars");
                Console.WriteLine("-----------------------------");

            }
        }

    }
}
