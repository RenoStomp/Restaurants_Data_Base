namespace Restaurants_Data_Base
{
    public class Ingredient
    {
        private string Name { get; set; }
        private double CostPerGram { get; set; }

        public Ingredient(string name, double costPerGram)
        {
            Name = name;
            CostPerGram = costPerGram;
        }
    }
}