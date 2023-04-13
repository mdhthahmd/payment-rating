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

    [HttpPost, Route("{employerId:int}/payments")]
    public IActionResult AddPayment([FromBody] AddPaymentDto dto, [FromRoute] int employerId)
    {

        if(employerId != dto.EmployerId) return BadRequest();

        var employer = _db.Employers.FirstOrDefault(a => a.Id == employerId);
        if(employer == null) return NotFound();

        var newPayment = new Payment(DateTime.Now, DateTime.Now, DateTime.Now, 100.4m);
        newPayment.EmployerId = employerId;

        _db.Payments.Add(newPayment);
        _db.SaveChanges();

        return Ok();
    }
}
