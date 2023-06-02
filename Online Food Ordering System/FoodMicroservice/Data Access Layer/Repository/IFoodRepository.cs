using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Repository
{
    // IFoodRepository.cs
    public interface IFoodRepository
    {
        IEnumerable<Food> GetAllFoods();
        Food GetFoodById(int id);
        void AddFood(Food food);
        void UpdateFood(int id, Food food);
        void DeleteFood(int id);
    }
}