using Restaurants_Data_Base.Files;
using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Menu;
using Restaurants_Data_Base.Place;
using System.Collections.Generic;

List<Ingredient> ingredients = WorkWithFiles.ReadIngredients();
List<Meal> meals = WorkWithFiles.ReadMeals(ingredients);
List<Restaurant> restaurants = WorkWithFiles.ReadRestaurants(meals);

//Dictionary<Ingredient, double> sostav = new Dictionary<Ingredient, double>()
//{
//    { ingredients[0], 100 },
//    { ingredients[1], 10 },
//    { ingredients[2], 333 },
//};
//ingredients.Add(new Ingredient("Milk", 4, Ingredient.Kind.Unknown));
//meals.Add(new Meal("Huinya", sostav));
//restaurants.Add(new Restaurant("Zalupen", "Hueglot", meals));

Menu.ExecuteMenu(restaurants, meals, ingredients);


WorkWithFiles.SaveData(ingredients, meals, restaurants);
//WorkWithFiles.SaveData(ingredients, meals, restaurants);