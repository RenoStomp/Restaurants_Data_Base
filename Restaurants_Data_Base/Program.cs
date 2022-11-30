using Restaurants_Data_Base.Files;
using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Menu;
using Restaurants_Data_Base.Place;

List<Ingredient> ingredients = WorkWithFiles.ReadIngredients();
List<Meal> meals = WorkWithFiles.ReadMeals(ingredients);
List<Restaurant> restaurants = WorkWithFiles.ReadRestaurants(meals);

Menu.ExecuteMenu(restaurants, meals, ingredients);