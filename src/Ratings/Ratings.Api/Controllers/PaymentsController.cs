using Microsoft.AspNetCore.Mvc;
using Ratings.Api.Models;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Infrastructure;

namespace Ratings.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private RatingContext _db;
    public PaymentsController(RatingContext db)
    {
        _db = db;
    }

    [HttpGet, Route("")]
    public IActionResult GetPayments()
    {
        var payments = _db.Payments
        .OrderByDescending(a => a.PaymentDate)
        .Select(a => new PaymentListDto {
            Id = a.Id,
            ContributionMonth = a.ContributionMonth,
            DueDate = a.DueDate,
            PaidAmount = a.PaidAmount,
            PaymentDate = a.PaymentDate,
            Status = a.Status ? "Paid" : "Pending"

        }).ToList();
       
        return Ok(payments);
    }


    [HttpPost, Route("")]
    public IActionResult AddPayment([FromBody] AddPaymentDto dto)
    {

        var employer = _db.Employers.FirstOrDefault(a => a.Id == dto.EmployerId);
        if(employer == null) return NotFound();

        var newPayment = new Payment(dto.ContributionDate, dto.PaymentDate, dto.Amount, dto.Status);
        newPayment.EmployerId = dto.EmployerId;

        _db.Payments.Add(newPayment);
        _db.SaveChanges();

        return Ok();
    }


   
}
