using Online_Food_Ordering_System.FoodMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.FoodMicroservice.Business_Layer.Service
{
    // IFoodService.cs
    public interface IFoodService
    {
        IEnumerable<FoodDto> GetAllFoods();
        FoodDto GetFoodById(int id);
        void AddFood(FoodDto foodDto);
        void UpdateFood(int id, FoodDto foodDto);
        void DeleteFood(int id);
    }
}
