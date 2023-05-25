using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Food_Ordering_System.FoodMicroservice.Business_Layer.DTO;
using Online_Food_Ordering_System.FoodMicroservice.Business_Layer.Service;
using System.Data;

namespace Online_Food_Ordering_System.FoodMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IEnumerable<FoodDto> GetAllFoods()
        {
           return _foodService.GetAllFoods();
        }

        [HttpGet("{id}")]
        public ActionResult<FoodDto> GetFoodById(int id)
        {
            try
            {
                var foodDto = _foodService.GetFoodById(id);
                return foodDto;
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return NotFound(ex.Message);
            }
        }

        //       [Authorize(Roles = "admin")]
        [HttpPost]
     
        public ActionResult CreateFood([FromBody] FoodDto foodDto)
        {
            try
            {
                _foodService.AddFood(foodDto);
                return Ok("FOOD ADDED");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return BadRequest(ex.Message);
            }
        }

       // [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
       
        public ActionResult UpdateFood(int id, [FromBody] FoodDto foodDto)
        {
            try
            {
                _foodService.UpdateFood(id, foodDto);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return NotFound(ex.Message);
            }
        }

       // [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
       
        public ActionResult DeleteFood(int id)
        {
            try
            {
                _foodService.DeleteFood(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return NotFound(ex.Message);
            }
        }
    }
}
 