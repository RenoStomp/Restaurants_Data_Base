using Restaurants_Data_Base;

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

Restaurant Kfc = new Restaurant("KFC", "PIDORAS", kfcMeals);

Kfc.PrintInfo();

foreach(Ingredient ingredient in allIngredients)
{
    ingredient.ShowTotalUsed();
}


Console.CursorVisible = false;
Console.ReadKey(true);