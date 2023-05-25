using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Repository
{
    // FoodRepository.cs
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _dbContext;

        public FoodRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Food> GetAllFoods()
        {
            return _dbContext.Foods.ToList();
        }

        public Food GetFoodById(int id)
        {
            return _dbContext.Foods.FirstOrDefault(f => f.Id == id);
        }

        public void AddFood(Food food)
        {
            _dbContext.Foods.Add(food);
            _dbContext.SaveChanges();   
        }

        public void UpdateFood(int id, Food food)
        {
            var existingFood = _dbContext.Foods.FirstOrDefault(f => f.Id == id);
            if (existingFood != null)
            {
                existingFood.FoodName = food.FoodName;
                existingFood.FoodType = food.FoodType;
                existingFood.Price = food.Price;
                existingFood.Description = food.Description;
                existingFood.ImageUrl = food.ImageUrl;

                _dbContext.Foods.Update(existingFood);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteFood(int id)
        {
            var food = _dbContext.Foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                _dbContext.Foods.Remove(food);
                _dbContext.SaveChanges();
            }
        }
    }
}
