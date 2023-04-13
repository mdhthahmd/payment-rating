using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratings.Application.Controllers.Helpers;
using Ratings.Application.Queries;

namespace Ratings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRatingQueries _ratingQueries;
    private readonly IUriHelper _uriHelper;

    public PaymentsController(IMediator mediator, IUriHelper uriHelper, IRatingQueries ratingQueries)
    {
        _mediator = mediator;
        _ratingQueries = ratingQueries;
        _uriHelper = uriHelper; 
    }


    [HttpGet, Route("")]
    public async Task<IActionResult> GetAllPaid([FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value;
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

        var pagedData = await _ratingQueries.GetPaginatedPaymentsAsync(validFilter.PageSize, validFilter.PageNumber);

        var totalRecords = await _ratingQueries.CountPaymentsAsync();

        var pagedReponse = PaginationHelper.CreatePagedReponse<PaymentHistoryDto>(pagedData, validFilter, totalRecords, _uriHelper, route);
        return Ok(pagedReponse);
    }

    [HttpGet, Route("pending")]
    public async Task<IActionResult> GetAllPending([FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value;
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

        var pagedData = await _ratingQueries.GetPaginatedPendingPaymentsAsync(validFilter.PageSize, validFilter.PageNumber);

        var totalRecords = await _ratingQueries.CountPendingPaymentsAsync();

        var pagedReponse = PaginationHelper.CreatePagedReponse<PendingPaymentDto>(pagedData, validFilter, totalRecords, _uriHelper, route);
        return Ok(pagedReponse);
    }


}
