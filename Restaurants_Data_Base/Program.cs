using Restaurants_Data_Base;

Fruit banana = new Fruit(Names.Banana.ToString(), 10);
Fruit apple = new Fruit(Names.Apple.ToString(), 12);
Fruit grape = new Fruit(Names.Grape.ToString(), 11);

Meat cowMeat = new Meat(Names.Beef.ToString(), 50);
Meat chikenMeat = new Meat(Names.Poultry.ToString(), 40);
//Meat fishMeat = new Meat(Names.Fish_Meat.ToString(), 70);
//Meat pigMeat = new Meat(Names.Pork.ToString(), 60);


Dictionary<Ingredient, double> kebabmixIngredients = new Dictionary<Ingredient, double>()
{
    {cowMeat, 200 },
    {chikenMeat, 200 }
};

Meal kebabmix = new Meal(MealNames.Kebab_Mix.ToString(), kebabmixIngredients);

//kebabmix.ShowIngredientsPrices();

Dictionary<Ingredient, double> fruitSaladIngredients = new Dictionary<Ingredient, double>()
{
    { banana, 50},
    { apple, 77},
    { grape, 99 }
};

Meal fruitSalad = new Meal(MealNames.Fruit_Salad.ToString(), fruitSaladIngredients);

//fruitSalad.ShowIngredientsPrices();

List<Meal> kfcMeals = new List<Meal> 
{ 
    fruitSalad, 
    kebabmix 
};

Restaurant Kfc = new Restaurant("KFC", "PIDORAS", kfcMeals);

Kfc.Print();