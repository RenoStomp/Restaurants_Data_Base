using Restaurants_Data_Base;

Fruit banana = new Fruit("Banana", 10);
Fruit apple = new Fruit("Apple", 12);
Fruit grape = new Fruit("Grape", 11);

Meat cowMeat = new Meat("Cow Meat", 50);
Meat chikenMeat = new Meat("Poultry", 40);
//Meat fishMeat = new Meat("Fish Meat", 70);
//Meat pigMeat = new Meat("Pork", 60);


Dictionary<Ingredient, double> kebabmixIngredients = new Dictionary<Ingredient, double>()
{
    {cowMeat, 200 },
    {chikenMeat, 200 }
};

Meal kebabmix = new Meal("Kebab Mix", kebabmixIngredients);

//kebabmix.ShowIngredientsPrices();

Dictionary<Ingredient, double> fruitSaladIngredients = new Dictionary<Ingredient, double>()
{
    { banana, 50},
    { apple, 77},
    { grape, 99 }
};

Meal fruitSalad = new Meal("Fruit Salad", fruitSaladIngredients);

//fruitSalad.ShowIngredientsPrices();

List<Meal> kfcMeals = new List<Meal> 
{ 
    fruitSalad, 
    kebabmix 
};

Restaurant Kfc = new Restaurant("KFC", "PIDORAS", kfcMeals);

Kfc.Print();