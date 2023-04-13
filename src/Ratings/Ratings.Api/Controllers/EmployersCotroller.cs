using Microsoft.AspNetCore.Mvc;
using Ratings.Api.Models;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Infrastructure;

namespace Ratings.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployersController : ControllerBase
{
    private RatingContext _db;
    public EmployersController(RatingContext db)
    {
        _db = db;
    }

    [HttpPost, Route("")]
    public IActionResult AddEmployer()
    {

        var newEmployer = new Employer();
        newEmployer.Name = "test";

        _db.Employers.Add(newEmployer);
        _db.SaveChanges();

        return Ok();
    }



    [HttpGet, Route("")]
    public IActionResult GetEmployersList()
    {
        var employers = _db.Employers.Select(a => new EmployerListDto 
        {
            Id = a.Id,
            Name  = a.Name,
            Stars = 1,
            Points = 100
        }).ToList();

        return Ok(employers);
    }
    



    [HttpGet, Route("dropdown-list")]
    public IActionResult GetEmployersForDropDown()
    {
        var employers = _db.Employers.Select(a => new EmployerDropDownList 
        {
            Id = a.Id,
            Name  = a.Name
        }).ToList();

        return Ok(employers);
    }

    
}
