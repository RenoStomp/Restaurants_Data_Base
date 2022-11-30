using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Place;

namespace Restaurants_Data_Base.Menu
{
    public static class Menu
    {
        /// <summary>
        /// Start an app
        /// </summary>
        public static void ExecuteMenu(List<Restaurant> allRestaurants, List<Ingredient> allIngredients)
        {
            Console.CursorVisible = false;
            ConsoleKey[] mainMenuKeys = new ConsoleKey[]
            {
                ConsoleKey.NumPad1,
                ConsoleKey.D1,
                ConsoleKey.NumPad2,
                ConsoleKey.D2,
                ConsoleKey.Escape,

            };

            PrintMainMenu();

            var option = PressButton(mainMenuKeys);
            switch (option)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    ShowRestaurants(allRestaurants, allIngredients);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    ShowIngredients(allRestaurants, allIngredients);
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
            Console.WriteLine();
            Console.WriteLine("[Esc]  -  Close app");

        }

        /// <summary>
        /// Shows all ingredients in every meal in every restaurant in one list with total weight
        /// for each ingredient and the most used ingredient
        /// </summary>
        /// <param name="allIngredients">List of all ingredients</param>
        public static void ShowIngredients(List<Restaurant> allRestaurants, List<Ingredient> allIngredients)
        {
            Ingredient mostUsed = new("", 0, Ingredient.Type.Unknown);

            foreach (Ingredient ingredient in allIngredients)
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
            ExecuteMenu(allRestaurants, allIngredients);
        }
        
        /// <summary>
        /// Shows all restaurants with their chefs 
        /// </summary>
        /// <param name="allRestaurants">List of all restaurants</param>
        /// <param name="allIngredients">List of all ingredients</param>
        public static void ShowRestaurants(List<Restaurant> allRestaurants, List<Ingredient> allIngredients)
        {
            Console.WriteLine();
            int numberOfRest = 0;
            foreach (var rest in allRestaurants)
            {
                numberOfRest++;
                Console.WriteLine($"[{numberOfRest}]  -  {rest.Name}  -  CHEF {rest.ChefsName}");
            }
            //Console.ResetColor();
            Console.WriteLine("\n\n[Backspace] BACK        [Esc] Close app");

            List<ConsoleKey> restaurantKeysList = new();

            // here I have added ASCII numbers of keys so I can add as many keys as I need
            // max amount of restaurants is 9
            //TODO: make a limit of 9 restaurants (9 keys on keyboard)
            for (int i = 0, j = 97, k = 49; i < numberOfRest; i++, j++, k++)  // j = 97 - NumPad1 , k = 49 - D1  ASCII
            {
                restaurantKeysList.Add((ConsoleKey)j);
                restaurantKeysList.Add((ConsoleKey)k);
            }
            restaurantKeysList.Add(ConsoleKey.Backspace);
            restaurantKeysList.Add(ConsoleKey.Escape);
            ConsoleKey[] restaurantKeys = restaurantKeysList.ToArray();

            var option = PressButton(restaurantKeys);
            switch (option)
            {
                case ConsoleKey.Backspace:
                    Console.Clear();
                    ExecuteMenu(allRestaurants, allIngredients);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }

            string test = option.ToString();
            int count = Convert.ToInt32(test[test.Length - 1]);    // даже не буду пытаться написать на англ...
            count -= 49;                                       // задолбался с этими внутренними значениями клавиш...
                                                               // а всё только ради того, что бы можно было на кнопашки тыкац сколько влезет...
            allRestaurants[count].PrintMenu();
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
                    ShowRestaurants(allRestaurants, allIngredients);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
