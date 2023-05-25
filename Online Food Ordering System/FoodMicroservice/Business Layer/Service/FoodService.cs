using Online_Food_Ordering_System.FoodMicroservice.Business_Layer.DTO;
using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;
using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Repository;

namespace Online_Food_Ordering_System.FoodMicroservice.Business_Layer.Service
{
    // FoodService.cs
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IEnumerable<FoodDto> GetAllFoods()
        {
            var foodEntities = _foodRepository.GetAllFoods();
            var foodDtos = new List<FoodDto>();

            foreach (var foodEntity in foodEntities)
            {
                var foodDto = MapToDto(foodEntity);
                foodDtos.Add(foodDto);
            }

            return foodDtos;
        }

        public FoodDto GetFoodById(int id)
        {
            var foodEntity = _foodRepository.GetFoodById(id);
            if (foodEntity == null)
            {
                throw new Exception("Food not found.");
            }

            var foodDto = MapToDto(foodEntity);
            return foodDto;
        }

        public void AddFood(FoodDto foodDto)
        {
            if (foodDto == null)
            {
                throw new ArgumentNullException(nameof(foodDto));
            }

            // Perform business logic validations
            if (string.IsNullOrWhiteSpace(foodDto.FoodName))
            {
                throw new Exception("Food name is required.");
            }

            if (string.IsNullOrWhiteSpace(foodDto.FoodType))
            {
                throw new Exception("Food type is required.");
            }

            // Map the DTO to the entity
            var foodEntity = MapToEntity(foodDto);

            // Perform any additional business logic

            // Add the food to the repository
            _foodRepository.AddFood(foodEntity);
        }

        public void UpdateFood(int id, FoodDto foodDto)
        {
            if (foodDto == null)
            {
                throw new ArgumentNullException(nameof(foodDto));
            }

            // Perform business logic validations
            if (string.IsNullOrWhiteSpace(foodDto.FoodName))
            {
                throw new Exception("Food name is required.");
            }

            if (string.IsNullOrWhiteSpace(foodDto.FoodType))
            {
                throw new Exception("Food type is required.");
            }

            var existingFood = _foodRepository.GetFoodById(id);
            if (existingFood == null)
            {
                throw new Exception("Food not found.");
            }

            // Map the DTO to the entity
            var foodEntity = MapToEntity(foodDto);

            // Perform any additional business logic

            // Update the food in the repository
            _foodRepository.UpdateFood(id, foodEntity);
        }

        public void DeleteFood(int id)
        {
            var existingFood = _foodRepository.GetFoodById(id);
            if (existingFood == null)
            {
                throw new Exception("Food not found.");
            }

            // Perform any additional business logic

            // Delete the food from the repository
            _foodRepository.DeleteFood(id);
        }

        private FoodDto MapToDto(Food foodEntity)
        {
            return new FoodDto
            {
                Id = foodEntity.Id,
                FoodName = foodEntity.FoodName,
                FoodType = foodEntity.FoodType,
                Price = foodEntity.Price,
                Description = foodEntity.Description,
                ImageUrl = foodEntity.ImageUrl
            };
        }

        private Food MapToEntity(FoodDto foodDto)
        {
            return new Food
            {
                Id = foodDto.Id,
                FoodName = foodDto.FoodName,
                FoodType = foodDto.FoodType,
                Price = foodDto.Price,
                Description = foodDto.Description,
                ImageUrl = foodDto.ImageUrl
            };
        }
    }
}