namespace Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models
{
    // Food.cs
    public class Food
    {
        public int Id { get; set; }
        public string FoodName { get; set; } = null!;
        public string FoodType { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
