using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Place;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Restaurants_Data_Base.Ingredients.Ingredient;

namespace Restaurants_Data_Base.Files
{
    public class WorkWithFiles
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
        public static List<Restaurant> ReadRestaurants(List<Meal> meals)
        {

            List<Restaurant> restaurants = new List<Restaurant>();

            using (StreamReader file = new StreamReader(@"..\..\..\Files\Restaurants.txt"))
            {
                List<string> lines = new List<string>();
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                foreach (string position in lines)
                {
                    string[] strings = position.Split('"');

                    string name = strings[0];
                    string chefsName = strings[1];
                    List<Meal> mealsInRestaurant = new List<Meal>();

                    for(int i = 2; i < strings.Length; i++)
                    {
                        foreach(Meal meal in meals)
                        {
                            if (strings[i].Equals(meal.Name))
                            {
                                mealsInRestaurant.Add(meal);
                                break;
                            }
                        }
                    }
                    restaurants.Add(new Restaurant(name, chefsName, mealsInRestaurant));
                }
            }

            return restaurants;
        }



        public static void SaveData(List<Ingredient> ingredients, List<Meal> meals, List<Restaurant> restaurants)
        {
            SaveRestaurants(restaurants);
            SaveMeals(meals);
            SaveIngredients(ingredients);
        }
        /// <summary>
        /// Saving all ingredients in saving file
        /// </summary>
        /// <param name="ingredients"></param>
        public static void SaveIngredients(List<Ingredient> ingredients)
        {
            using (StreamWriter file = new StreamWriter(@"..\..\..\Files\Ingredients.txt", false))
            {
                foreach(Ingredient ingredient in ingredients)
                {
                    string[] line = new string[] 
                    { 
                        ingredient.Name, 
                        ingredient.CostPerGram.ToString(), 
                        ingredient.TypeOfIngredient.ToString()
                    };
                    string readyLine = string.Join('\"', line);
                    file.WriteLine(readyLine);
                }
            }
        }

        /// <summary>
        ///Saving all meals in file
        /// </summary>
        /// <param name="meals"></param>
        public static void SaveMeals(List<Meal> meals)
        {
            using (StreamWriter file = new StreamWriter(@"..\..\..\Files\Meals.txt", false))
            {
                foreach (Meal meal in meals)
                {
                    string readyLine = "";
                    for (int i = 0; i < meal.Ingredients.Count; i++)
                    {
                        string lll = "";
                        List<string> almostLine = new List<string>();
                        
                        foreach (KeyValuePair<Ingredient, double> ingreientAndWeight in meal.Ingredients)
                        {
                            string[] ingredient = new string[]
                            {
                            ingreientAndWeight.Key.Name,
                            ingreientAndWeight.Value.ToString()
                            };
                            lll = string.Join('\'', ingredient);
                            almostLine.Add(lll);
                        }
                        lll = string.Join("\"",almostLine);
                        string[] line = new string[]
                        {
                        meal.Name,
                        lll
                        };
                        readyLine = string.Join('\"', line);
                    }
                    file.WriteLine(readyLine);
                }
            }

        }

        /// <summary>
        ///Saving all restaurants in file
        /// </summary>
        /// <param name="meals"></param>
        public static void SaveRestaurants(List<Restaurant> restaurants)
        {
            using (StreamWriter file = new StreamWriter(@"..\..\..\Files\Restaurants.txt", false))
            {
                foreach (Restaurant restaurant in restaurants)
                {
                    List<string> mealsNames = new List<string>();
                    foreach(Meal Meals in restaurant.Meals.Keys)
                    {
                        mealsNames.Add(Meals.Name);
                    }
                    string almostLine = string.Join("\"", mealsNames);
                    string[] line = new string[]
                    {
                        restaurant.Name,
                        restaurant.ChefsName,
                        almostLine
                    };
                    string readyLine = string.Join('\"', line);
                    file.WriteLine(readyLine);
                }
            }
        }
    }
}
