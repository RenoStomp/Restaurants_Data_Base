using Restaurants_Data_Base.Files;
using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Menu;
using Restaurants_Data_Base.Place;

List<Ingredient> ingredients = FileReader.ReadIngredients();
List<Meal> meals = FileReader.ReadMeals(ingredients);
List<Restaurant> restaurants = FileReader.ReadRestaurants(meals);


Menu.ExecuteMenu(restaurants, ingredients);






