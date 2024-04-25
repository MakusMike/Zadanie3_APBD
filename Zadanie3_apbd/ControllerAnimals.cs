using Microsoft.AspNetCore.Mvc;

namespace Zadanie3_apbd;

[Route("api/[controller]")]
[ApiController]
public class ControllerAnimals : ControllerBase
{
    private readonly string connectionstring;

    public ControllerAnimals(string connectionstring)
    {
        this.connectionstring = connectionstring;
    }
    


}