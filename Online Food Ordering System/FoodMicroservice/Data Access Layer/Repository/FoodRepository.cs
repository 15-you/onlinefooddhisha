using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Repository
{

    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _appDbContext;

        public FoodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Food> GetAllFoods()
        {
            return _appDbContext.Foods.ToList();
        }

        public Food GetFoodById(int id)
        {
            return _appDbContext.Foods.FirstOrDefault(f => f.Id == id);
        }

        public void AddFood(Food food)
        {
            _appDbContext.Foods.Add(food);
            _appDbContext.SaveChanges();
        }

        public void UpdateFood(int id, Food food)
        {
            var existingFood = _appDbContext.Foods.FirstOrDefault(f => f.Id == id);
            if (existingFood != null)
            {
                existingFood.FoodName = food.FoodName;
                existingFood.FoodType = food.FoodType;
                existingFood.Price = food.Price;
                existingFood.Description = food.Description;
                existingFood.ImageUrl = food.ImageUrl;

                _appDbContext.Foods.Update(existingFood);
                _appDbContext.SaveChanges();
            }
        }

        public void DeleteFood(int id)
        {
            var food = _appDbContext.Foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                _appDbContext.Foods.Remove(food);
                _appDbContext.SaveChanges();
            }
        }
    }
}
