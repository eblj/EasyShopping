using EasyShopping.Coupon.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopping.Coupon.API.Controllers
{
    [ApiController]
    [Route("coupon")]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("find-by-code/{code}")]
        public async Task<IActionResult> FindByCode(string code)
        {
            try
            {
                FindCouponByCodeQuery query = new FindCouponByCodeQuery(code);
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }
    }
}
