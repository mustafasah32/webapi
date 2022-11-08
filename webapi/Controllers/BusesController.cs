using Microsoft.AspNetCore.Mvc;
using webapi.DomainTier;









namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]
public class BusesController : ControllerBase
{
    private static readonly List<Bus> Buses = new List<Bus>{
        new Bus(){
            Id=1,
            Color="pink"
        },
        new Bus(){
            Id=2,
            Color="lightpink"
        },
        new Bus(){
            Id=3,
            Color="yellow"
        },
        new Bus(){
            Id=4,
            Color="blue"
        },
    };

    private readonly ILogger<BusesController> _logger;

    public BusesController(ILogger<BusesController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public Bus GetBus(int id)
    {
        return Buses.Find(t=>t.Id==id);
    }

    [HttpGet()]
    public IEnumerable<Bus> GetBuses()
    {
        return Buses.ToArray();
    }
}
