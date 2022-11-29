namespace Restaurants_Data_Base.Place
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ChefsName { get; set; }
        /// <summary>
        /// Dictionary for saving meal with sell price
        /// </summary>
        public Dictionary<Meal, double> Meals { get; set; }


        public Restaurant(string name, string chefsName, List<Meal> meals)
        {
            Name = name;
            ChefsName = chefsName;
            Meals = new Dictionary<Meal, double>();
            foreach (Meal meal in meals)
            {
                double mealPrice = Math.Round(meal.MealPrice * 1.2, 2);
                Meals.Add(meal, mealPrice);
            }
        }
        /// <summary>
        /// Shows all menu of the restaurant, every ingredient in it, weight, real price and sell price
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine(Name.ToUpper());

            Console.WriteLine($"\nChef - {ChefsName}\n");

            Console.WriteLine("Menu:");
            Console.WriteLine();
            foreach (var meal in Meals)
            {
                meal.Key.ShowIngredientsAndPrice();
                Console.WriteLine($"{meal.Key.Name}'s sell price - {meal.Value} dollars");
                Console.WriteLine("-----------------------------------------------\n");

            }
        }




    }
}
