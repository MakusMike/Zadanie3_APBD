using Microsoft.AspNetCore.Mvc;

namespace Zadanie3_apbd;

[ApiController]
[Route("api/animals")]
public class ControllerAnimals : Controller
{
    private readonly string _connectionstring =
        "Data source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s25713;Integreted Security=true";
    public ControllerAnimals(string _connectionstring)
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimal([FromQuery] string orderBy)
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAnimal([FromBody] Animal animal)
    {
        
    }
    
}