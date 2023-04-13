using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratings.Application.Commands.AddPayment;
using Ratings.Application.Commands.MarkPaymentAsPaid;
using Ratings.Application.Controllers.Helpers;
using Ratings.Application.Queries;

namespace Ratings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRatingQueries _ratingQueries;
    private readonly IUriHelper _uriHelper;

    public EmployersController(IMediator mediator, IUriHelper uriHelper, IRatingQueries ratingQueries)
    {
        _mediator = mediator;
        _ratingQueries = ratingQueries;
        _uriHelper = uriHelper; 
    }

    [HttpPost, Route("{employerId:int}/payments")]
    public async Task<IActionResult> AddPayment([FromRoute] int employerId, [FromBody] AddPaymentCommand request)
    {
        if(employerId != request.EmployerId) return BadRequest();

        bool commandResult = false;
        commandResult = await _mediator.Send(request);

        if(!commandResult) return BadRequest();

        return Ok();
    }

    [HttpPost, Route("{employerId:int}/payments/{paymentId:int}")]
    public async Task<IActionResult> MarkPaymentAsPaid([FromRoute] int employerId, [FromRoute] int paymentId)
    {
        var request = new MarkPaymentAsPaidCommand
        {
            EmployerId = employerId,
            PaymentId = paymentId
        };

        bool commandResult = false;

        try
        {
            commandResult = await _mediator.Send(request);
        }
        catch(Exception e)
        {
            var x = e.Message;
        }

        if(!commandResult) return BadRequest();

        return Ok();
    }

    [HttpGet, Route("")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value;
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

        var pagedData = await _ratingQueries.GetPaginatedEmployersAsync(validFilter.PageSize, validFilter.PageNumber);

        var totalRecords = await _ratingQueries.CountEmployersAsync();

        var pagedReponse = PaginationHelper.CreatePagedReponse<EmployerDto>(pagedData, validFilter, totalRecords, _uriHelper, route);
        return Ok(pagedReponse);
    }

    [HttpGet, Route("dropdown")]
    public async Task<IActionResult> GetDropdown()
    {
        var dropdownItems = await _ratingQueries.GetEmployersForDropdownAsync();
        return Ok(dropdownItems);
    }
}
