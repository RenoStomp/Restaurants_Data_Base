using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Place;
using System.Collections.Generic;

namespace Restaurants_Data_Base.Menu
{
    public static class Menu
    {
        /// <summary>
        /// Start an app
        /// </summary>
        public static void ExecuteMenu(List<Restaurant> restaurants, List<Meal> meals, List<Ingredient> ingredients)
        {
            Console.Clear();
            Console.CursorVisible = false;
            ConsoleKey[] mainMenuKeys = new ConsoleKey[]
            {
                ConsoleKey.NumPad1,
                ConsoleKey.D1,
                ConsoleKey.NumPad2,
                ConsoleKey.D2,
                ConsoleKey.Escape,
                ConsoleKey.NumPad3,
                ConsoleKey.D3
            };

            PrintMainMenu();

            var option = PressButton(mainMenuKeys);
            switch (option)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    ShowRestaurants(restaurants, meals, ingredients);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    ShowIngredients(restaurants, meals, ingredients);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    AddSomething(ref ingredients, ref meals, ref restaurants);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

            }

        }

        /// <summary>
        /// Accepting only allowed buttons
        /// </summary>
        /// <returns>ConsoleKey that is allowed</returns>
        public static ConsoleKey PressButton(ConsoleKey[] keys)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!keys.Contains(key.Key))
            {
                key = Console.ReadKey(true);
            }
            return key.Key;
        }

        /// <summary>
        /// Shows Main Menu
        /// </summary>
        public static void PrintMainMenu()
        {
            Console.Write("\nWelcome to the ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("MAIN MENU");
            Console.ResetColor();
            Console.WriteLine("\nChoose an option:");

            Console.SetCursorPosition(0, 5);
            Console.WriteLine("[1]    -  Restaurants");
            Console.WriteLine("[2]    -  The most popular ingredient in all restaurants");
            Console.WriteLine("[3]    -  Add something");


            Console.WriteLine();
            Console.WriteLine("[Esc]  -  Close app");

        }

        /// <summary>
        /// Shows all ingredients in every meal in every restaurant in one list with total weight
        /// for each ingredient and the most used ingredient
        /// </summary>
        /// <param name="allIngredients">List of all ingredients</param>
        public static void ShowIngredients(List<Restaurant> restaurants, List<Meal> meals, List<Ingredient> ingredients)
        {
            Ingredient mostUsed = new("", 0, Ingredient.Kind.Unknown);

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ShowTotalUsed();
                if (mostUsed.TotalUsing > ingredient.TotalUsing)
                {
                    continue;
                }
                mostUsed = ingredient;
            }
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Most used ingredient is ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(mostUsed.Name);
            Console.ResetColor();
            Console.Write(" - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double totalWeight = Math.Round(mostUsed.TotalUsing / 1000, 3);
            Console.WriteLine($"{totalWeight} kilos");
            Console.ResetColor();
            Console.WriteLine("\n\n[Backspace] BACK        [Esc] Close app");

            ConsoleKeyInfo back;
            do
            {
                back = Console.ReadKey(true);
            } while (back.Key != ConsoleKey.Backspace && back.Key != ConsoleKey.Escape);
            if (back.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            Console.Clear();
            ExecuteMenu(restaurants, meals, ingredients);
        }

        /// <summary>
        /// Shows all restaurants with their chefs 
        /// </summary>
        /// <param name="restaurants">List of all restaurants</param>
        /// <param name="ingredients">List of all ingredients</param>
        public static void ShowRestaurants(List<Restaurant> restaurants, List<Meal> meals, List<Ingredient> ingredients)
        {
            int numberOfRest = 0;
            List<string> lines = new List<string>();
            foreach (var rest in restaurants)
            {
                numberOfRest++;
                string line = $"  {rest.Name} - CHEF {rest.ChefsName}";
                lines.Add(line);
            }
            int index = 0;
            string title = $"Choose a restaurant:";
            var keyInfo = ShowOptionsAndChoose(title, lines, index: ref index);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Backspace:
                    Console.Clear();
                    ExecuteMenu(restaurants, meals, ingredients);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Enter:
                    PrintMenuOfRestaurant(restaurants[index], restaurants, meals, ingredients);
                    break;
            }
        }

        /// <summary>
        /// Shows all options and returns the line you have choose
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="lines">List of lines</param>
        /// <param name="index">int parameter for chosen line</param>
        /// <returns></returns>
        public static ConsoleKeyInfo ShowOptionsAndChoose(string title, List<string> lines, ref int index)
        {
            ShowOptions(title, lines, index);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index + 1 < lines.Count)
                        {
                            index++;
                        }
                        ShowOptions(title, lines, index);
                        break;
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0)
                        {
                            index--;
                        }
                        ShowOptions(title, lines, index);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter);
            return keyInfo;
        }

        /// <summary>
        /// Shows all menu of the restaurant
        /// </summary>
        public static void PrintMenuOfRestaurant(Restaurant restaurant, List<Restaurant> restaurants, List<Meal> meals, List<Ingredient> ingredients)
        {
            int numberOfMeal = 0;
            List<string> lines = new List<string>();
            foreach (var meal in restaurant.Meals)
            {
                numberOfMeal++;
                string line = $"  {meal.Key.Name}  -  {meal.Value} $  -  {meal.Key.MealWeight} grams";
                lines.Add(line);
            }
            int index = 0;
            string title = $" {restaurant.Name}\n" +
                $" Chef - {restaurant.ChefsName}\n\n" +
                $" Menu:";
            var keyInfo = ShowOptionsAndChoose(title, lines, index: ref index);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Backspace:
                    Console.Clear();
                    ShowRestaurants(restaurants, meals, ingredients);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Enter:
                    var choosenMeal = restaurant.Meals.ElementAt(index);
                    choosenMeal.Key.ShowIngredientsAndPrice();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{choosenMeal.Key.Name}'s sell price - {choosenMeal.Value} dollars");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------------\n");

                    Console.WriteLine("\n\n[Backspace] BACK        [Esc] Close app");

                    ConsoleKey[] keys = new ConsoleKey[]
                    {
                        ConsoleKey.Backspace,
                        ConsoleKey.Escape
                    };
                    var choice = PressButton(keys);
                    switch (choice)
                    {
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            PrintMenuOfRestaurant(restaurant, restaurants, meals, ingredients);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Shows menu of options with title
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="lines">List of lines</param>
        /// <param name="index">int parameter for displaying chosen line</param>
        public static void ShowOptions(string title, List<string> lines, int index)
        {
            Console.Clear();
            Console.WriteLine($"{title}\n");
            for (int i = 0; i < lines.Count; i++)
            {
                if (index.Equals(i))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" >> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(lines[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("[UP] Up  [Down] Down  [Enter] Choose");
            Console.WriteLine("\n[Backspace] BACK        [Esc] Close app");


        }

        /// <summary>
        /// Adding any element you need
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="meals"></param>
        /// <param name="restaurants"></param>
        public static void AddSomething(ref List<Ingredient> ingredients, ref List<Meal> meals, ref List<Restaurant> restaurants)
        {
            Console.Clear();
            Console.WriteLine("\nChoose what you want to add:\n");
            Console.WriteLine("[R]  -  Restaurant\n" +
                "[M]  -  Meal\n" +
                "[I]  -  Ingredient");
            Console.WriteLine("\n[Backspace] BACK        [Esc] Close app");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.R && key.Key != ConsoleKey.M && key.Key != ConsoleKey.I && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape);
            switch (key.Key)
            {
                case ConsoleKey.Backspace:
                    ExecuteMenu(restaurants, meals, ingredients);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.I:
                    AddIngredient(ref ingredients, ref meals, ref restaurants);
                    break;
                case ConsoleKey.M:
                    AddMeal(ref ingredients, ref meals, ref restaurants);
                    break;
                case ConsoleKey.R:
                    AddRestaurant(ref ingredients, ref meals, ref restaurants);
                    break;

            }
        }

        public static void AddIngredient(ref List<Ingredient> ingredients, ref List<Meal> meals, ref List<Restaurant> restaurants) 
        { 

        }
        public static void AddMeal(ref List<Ingredient> ingredients, ref List<Meal> meals, ref List<Restaurant> restaurants)
        {

        }
        public static void AddRestaurant(ref List<Ingredient> ingredients, ref List<Meal> meals, ref List<Restaurant> restaurants)
        {

        }
    }
}
