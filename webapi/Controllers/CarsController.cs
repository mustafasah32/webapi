using Microsoft.AspNetCore.Mvc;
using webapi.DomainTier;
using webapi.VwModels;

















namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private static readonly List<Car> Cars = new List<Car>{
        new Car(){
            Id=1,
            Color="pink",
            LightsTurnedOff=false
        },
        new Car(){
            Id=2,
            Color="lightpink",
            LightsTurnedOff=false
        },
        new Car(){
            Id=3,
            Color="yellow",
            LightsTurnedOff=true
        },
        new Car(){
            Id=4,
            Color="blue",
            LightsTurnedOff=false
        },
    };

    private readonly ILogger<CarsController> _logger;

    public CarsController(ILogger<CarsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public Car GetCar(int id)
    {
        return Cars.Find(t => t.Id == id);
    }

    [HttpPut()]
    public IActionResult TurnLights([FromBody] TurnLightsModel turnLightsModel)
    {
        var car = Cars.SingleOrDefault(t => t.Id == turnLightsModel.Id);

        if (car is null)
        {
            return BadRequest();
        }

        car.LightsTurnedOff = turnLightsModel.TurnedOff;

        return Ok();
    }

    [HttpPost()]
    public IActionResult AddCar([FromBody] AddCarModel addCarModel)
    {
        if (addCarModel.Id <= 0 || Cars.Any(t => t.Id == addCarModel.Id))
        {
            return BadRequest();
        }

        var car = new Car();
        car.Id = addCarModel.Id;
        car.Color = addCarModel.Color;
        car.LightsTurnedOff = addCarModel.LightsTurnedOff;

        Cars.Add(car);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {
        var car = Cars.SingleOrDefault(t => t.Id == id);

        if (car is null)
        {
            return BadRequest();
        }

        Cars.Remove(car);

        return Ok();
    }

    [HttpGet()]
    public IEnumerable<Car> GetCars()
    {
        return Cars.ToArray();
    }
}
