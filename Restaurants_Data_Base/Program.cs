using Restaurants_Data_Base;

Fruit banana = new Fruit("Banana", 10);
Fruit apple = new Fruit("Apple", 12);
Fruit grape = new Fruit("Grape", 11);

Dictionary<Ingredient, double> fruitSaladIngredients = new Dictionary<Ingredient, double>()
{
    { banana, 50},
    { apple, 77},
    { grape, 99 }
};

Meal fruitSalad = new Meal("FruitSalad", fruitSaladIngredients);

fruitSalad.ShowIngredientsPrices();