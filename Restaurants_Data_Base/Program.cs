using Restaurants_Data_Base;
using Restaurants_Data_Base.Ingredients;
using Restaurants_Data_Base.Menu;
using Restaurants_Data_Base.Place;
using System.Reflection.PortableExecutable;

ReadIngredients();
Console.WriteLine();
ReadMeals();
Console.WriteLine();
ReadRestaurants();
Console.ReadKey();

Ingredient banana = new Ingredient(Names.Banana, 10, Ingredient.Kind.Fruit);
Ingredient apple = new Ingredient(Names.Apple, 12, Ingredient.Kind.Fruit);
Ingredient grape = new Ingredient(Names.Grape, 11, Ingredient.Kind.Fruit);

Ingredient cowMeat = new Ingredient(Names.Beef, 50, Ingredient.Kind.Meat);
Ingredient chikenMeat = new Ingredient(Names.Poultry, 40, Ingredient.Kind.Meat);
Ingredient fishMeat = new Ingredient(Names.Fish_Meat, 70, Ingredient.Kind.Meat);
Ingredient pigMeat = new Ingredient(Names.Pork, 60, Ingredient.Kind.Meat);

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

Restaurant kfc = new Restaurant("KFC", "Hui Znaet", kfcMeals);

List<Restaurant> allRestaurants = new List<Restaurant>()
{
    kfc,

};

Menu.ExecuteMenu(allRestaurants, allIngredients);










List<Ingredient> ReadIngredients()
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
    }

    return ingredients;
}
List<Meal> ReadMeals()
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
    }

    return meals;

}
List<Restaurant> ReadRestaurants()
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
    }

    return restaurants;
}