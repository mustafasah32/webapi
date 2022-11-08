using Microsoft.AspNetCore.Mvc;
using webapi.DomainTier;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]
public class TrucksController : ControllerBase
{
    private static readonly List<Truck> Trucks = new List<Truck>{
        new Truck(){
            Id=1,
            Color="pink"
        },
        new Truck(){
            Id=2,
            Color="lightpink"
        },
        new Truck(){
            Id=3,
            Color="yellow"
        },
        new Truck(){
            Id=4,
            Color="blue"
        },
    };

    private readonly ILogger<TrucksController> _logger;

    public TrucksController(ILogger<TrucksController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public Truck GetTruck(int id)
    {
        return Trucks.Find(t=>t.Id==id);
    }

    [HttpGet()]
    public IEnumerable<Truck> GetTrucks()
    {
        return Trucks.ToArray();
    }
}
