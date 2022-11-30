namespace Restaurants_Data_Base.Place
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string ChefsName { get; set; }
        /// <summary>
        /// Dictionary for saving meal with sell price(20% extra)
        /// </summary>
        public Dictionary<Meal, double> Meals { get; set; }


        public Restaurant(string name, string chefsName, List<Meal> meals)
        {
            Name = name;
            ChefsName = chefsName;
            Meals = new Dictionary<Meal, double>();
            foreach (Meal meal in meals)
            {   //here we calculate sell price with 20% extra
                double mealPrice = Math.Round(meal.MealPrice * 1.2, 2);
                Meals.Add(meal, mealPrice);
            }
        }




    }
}
