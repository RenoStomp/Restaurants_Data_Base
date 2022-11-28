namespace Restaurants_Data_Base
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double CostPerGram { get; set; }

        public Ingredient(string name, double costPerGram)
        {
            Name = name;
            CostPerGram = costPerGram;
        }
        public void Print()
        {
            Console.WriteLine($"{Name} - {CostPerGram}");
        }
    }
}