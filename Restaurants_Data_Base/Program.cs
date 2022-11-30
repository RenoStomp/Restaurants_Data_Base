using Restaurants_Data_Base.Files;
using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Menu;
using Restaurants_Data_Base.Place;

List<Ingredient> ingredients = FileReader.ReadIngredients();
//Console.WriteLine();

List<Meal> meals = FileReader.ReadMeals(ingredients);
//foreach (var meal in meals)
//{
//    meal.ShowIngredientsAndPrice();
//    Console.ReadKey();
//}
//Console.WriteLine();

List<Restaurant> restaurants = FileReader.ReadRestaurants(meals);
//foreach(Restaurant restaurant in restaurants)
//{
//    Console.WriteLine($"{restaurant.Name}"); 
//}

//Console.ReadKey();



Menu.ExecuteMenu(restaurants, ingredients);






