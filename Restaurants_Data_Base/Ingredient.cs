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
        public double weigth { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} - {weigth} gr");
        }



            
    }
}