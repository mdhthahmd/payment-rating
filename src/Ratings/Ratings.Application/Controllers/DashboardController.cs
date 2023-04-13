using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratings.Application.Commands.AddPayment;
using Ratings.Application.Commands.MarkPaymentAsPaid;
using Ratings.Application.Controllers.Helpers;
using Ratings.Application.Queries;

namespace Ratings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRatingQueries _ratingQueries;
    private readonly IUriHelper _uriHelper;

    public DashboardController(IMediator mediator, IUriHelper uriHelper, IRatingQueries ratingQueries)
    {
        _mediator = mediator;
        _ratingQueries = ratingQueries;
        _uriHelper = uriHelper; 
    }

    [HttpGet, Route("")]
    public async Task<IActionResult> GetRanked()
    {
        var best = await _ratingQueries.GetHighestRankedEmployers(5);
        var worst = await _ratingQueries.GetLowesttRankedEmployers(5);

        var vm = new DashboardRanking
        {
            Best = best,
            Worst = worst
        };

        return Ok(vm);
    }
}
