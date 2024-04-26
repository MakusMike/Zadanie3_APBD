using Microsoft.AspNetCore.Mvc;

namespace Zadanie3_apbd;

[ApiController]
[Route("api/animals")]
public class ControllerAnimals : Controller
{
    private readonly I_AnimalDataService _animalDataService;
    public ControllerAnimals(I_AnimalDataService dataService)
    {
        _animalDataService = dataService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimals([FromQuery] string orderBy)
    {
        return Ok(_animalDataService.GetAnimals(orderBy)); 
    }

    [HttpPost]
    public async Task<IAsyncResult> UpdateAnimal([FromBody] Animal animal)
    {
        _animalDataService.AddAnimal(animal);
        return null;
    }

    [HttpPut("{idAnimal}")]
    public async Task<IActionResult> PutAnimalById([FromRoute]string idAnimal, [FromBody]Animal animal)
    {
        _animalDataService.UpdateAnimal(idAnimal, animal);
        return Ok();
    }

    [HttpDelete("{idAnimal}")]
    public async Task<IActionResult> DeleteAnimal([FromRoute]string idAnimal)
    {
        _animalDataService.DeleteAnimal(idAnimal);
        return Ok();
    }
    
}