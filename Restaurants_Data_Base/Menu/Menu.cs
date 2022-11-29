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
        public static void ExecuteMenu()
        {

            Fruit banana = new Fruit(Names.Banana, 10);
            Fruit apple = new Fruit(Names.Apple, 12);
            Fruit grape = new Fruit(Names.Grape, 11);

            Meat cowMeat = new Meat(Names.Beef, 50);
            Meat chikenMeat = new Meat(Names.Poultry, 40);
            Meat fishMeat = new Meat(Names.Fish_Meat, 70);
            Meat pigMeat = new Meat(Names.Pork, 60);

            List<Ingredient> allIngredients = new List<Ingredient>
            {
                banana,
                apple,
                grape,
                cowMeat,
                chikenMeat,
                fishMeat,
                pigMeat,

            };

            Dictionary<Ingredient, double> beefKebabIngredients = new Dictionary<Ingredient, double>()
            {
                {cowMeat, 250 }
            };
            Meal beefKebab = new Meal(MealNames.Beef_Kebab, beefKebabIngredients);

            Dictionary<Ingredient, double> chickenKebabIngredients = new Dictionary<Ingredient, double>()
            {
                {chikenMeat, 300 }
            };
            Meal chickenKebab = new Meal(MealNames.Chicken_Kebab, chickenKebabIngredients);

            Dictionary<Ingredient, double> kebabmixIngredients = new Dictionary<Ingredient, double>()
            {
                {cowMeat, 100 },
                {chikenMeat, 100 }
            };
            Meal kebabmix = new Meal(MealNames.Kebab_Mix, kebabmixIngredients);

            Dictionary<Ingredient, double> fruitSaladIngredients = new Dictionary<Ingredient, double>()
            {
                { banana, 50},
                { apple, 77},
                { grape, 99 }
            };
            Meal fruitSalad = new Meal(MealNames.Fruit_Salad, fruitSaladIngredients);

            List<Meal> kfcMeals = new List<Meal>
            {
                fruitSalad,
                kebabmix,
                beefKebab,
                chickenKebab
            };

            Restaurant kfc = new Restaurant("KFC", "PIDORAS", kfcMeals);

            List<Restaurant> allRestaurants = new List<Restaurant>()
            {
                kfc,

            };

            //////////
            //Kfc.PrintInfo();

            //ShowIngredients(allIngredients);




            Console.CursorVisible = false;
            //Console.ReadKey(true);
            //////////

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
                case ConsoleKey.D1: case ConsoleKey.NumPad1:
                    Console.Clear();
                    ShowRestaurants(allRestaurants);
                    break;

                case ConsoleKey.D2: case ConsoleKey.NumPad2:
                    Console.Clear();
                    ShowIngredients(allIngredients);
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
        /// <param name="allIngredients"></param>

        public static void ShowIngredients(List<Ingredient> allIngredients)
        {
            Ingredient mostUsed = new("", 0);

            foreach (Ingredient ingredient in allIngredients)
            {
                ingredient.ShowTotalUsed();
                if(mostUsed.TotalUsing > ingredient.TotalUsing)
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
            if(back.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            Console.Clear();
            ExecuteMenu();
        }

        public static void ShowRestaurants(List<Restaurant> allRestaurants)
        {
            Console.WriteLine();
            int numberOfRest = 0;
            foreach(var rest in allRestaurants)
            {
                numberOfRest++;
                Console.WriteLine($"[{numberOfRest}]  -  {rest.Name}  -  CHEF {rest.ChefsName}");
            }
            Console.ResetColor();
            Console.WriteLine("\n\n[Backspace] BACK        [Esc] Close app");

            List<ConsoleKey> restaurantKeysList = new();

            // here I have added UTF numbers of keys so I can add as many keys as I need
            for(int i = 0, j = 97, k = 49; i < numberOfRest; i++, j++, k++)
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
                    ExecuteMenu();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }

            string test = option.ToString();
            int count = Convert.ToInt32(test[test.Length-1]);    // даже не буду пытаться написать на англ...
            count -= 49;                                       // задолбался с этими внутренними значениями клавиш...
                                     // а всё только ради того, что бы можно было на кнопашки тыкац сколько влезет...
            Console.Clear();
            allRestaurants[count].PrintInfo();
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
                    ShowRestaurants(allRestaurants);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
