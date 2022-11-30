using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Place;
using static Restaurants_Data_Base.Ingredients.Ingredient;

namespace Restaurants_Data_Base.Files
{
    public class FileReader
    {
        /// <summary>
        /// Returns List of ingredients from .txt file
        /// </summary>
        /// <returns></returns>
        public static List<Ingredient> ReadIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (StreamReader file = new StreamReader(@"..\..\..\Files\Ingredients.txt"))
            {
                List<string> lines = new List<string>();
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                    Console.WriteLine(line);
                }

                foreach(string position in lines)
                {
                    string[] strings = position.Split('"');
                    string name = strings[0];
                    double.TryParse(strings[1], out double costPerGram);
                    Enum.TryParse(strings[2], out Kind kind);
                    ingredients.Add(new Ingredient(name, costPerGram, kind));
                }
            }

            return ingredients;
        }

        /// <summary>
        /// Returns List of meals from .txt file
        /// </summary>
        /// <returns></returns>
        public static List<Meal> ReadMeals(List<Ingredient> ingredients)
        {

            List<Meal> meals = new List<Meal>();

            using (StreamReader file = new StreamReader(@"..\..\..\Files\Meals.txt"))
            {
                List<string> lines = new List<string>();
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                    Console.WriteLine(line);
                }
                foreach (string position in lines)
                {
                    Dictionary<Ingredient, double> compound = new Dictionary<Ingredient, double>(); 
                    string[] strings = position.Split('"');
                    string name = strings[0];
                    for(int i = 0, j = 1; j < strings.Length; j++)
                    {
                        string[] stringsCompound = strings[j].Split('\'');
                        double.TryParse(stringsCompound[1], out double amount);

                        foreach (Ingredient ingredient in ingredients)
                        {
                            if (ingredient.Name.Equals(stringsCompound[0]))
                            {
                                compound.Add(ingredient, amount);
                                break;
                            }
                        }
                    }
                    meals.Add(new Meal(name, compound));
                }
            }
            return meals;
        }

        /// <summary>
        /// Returns List of restaurants from .txt file
        /// </summary>
        /// <returns></returns>
        public static List<Restaurant> ReadRestaurants()
        {

            List<Restaurant> restaurants = new List<Restaurant>();

            using (StreamReader file = new StreamReader(@"..\..\..\Files\Restaurants.txt"))
            {
                List<string> lines = new List<string>();
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                    Console.WriteLine(line);
                }
                //foreach (string position in lines)
                //{
                //    string[] strings = position.Split('"');

                //    string name = strings[0];
                //    double.TryParse(strings[1], out double costPerGram);
                //    Enum.TryParse(strings[2], out Kind kind);

                //    restaurants.Add(new Restaurant(name, costPerGram, kind));
                //}
            }

            return restaurants;
        }


    }
}
