using Restaurants_Data_Base;

Fruit banana = new Fruit("Banana", 10);
Fruit apple = new Fruit("Apple", 12);
Fruit grape = new Fruit("Grape", 11);
List<Ingredient> ingredients = new List<Ingredient>()
{
    banana,
    apple,
    grape
};

foreach(Ingredient ingredient in ingredients)
{
    ingredient.Print();
}