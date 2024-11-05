using EasyShopping.Coupon.Application.CQRS.Commands;
using EasyShopping.Coupon.Application.CQRS.Queries;
using EasyShopping.Coupon.Application.DTOs.Coupon;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CouponViewModel model)
        {
            try
            {
                CreateCouponCommand command = new CreateCouponCommand(model);
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpDelete("delete/{couponId}")]
        public async Task<IActionResult> Delete(Guid couponId)
        {
            try
            {
                DeleteCouponByIdCommand command = new DeleteCouponByIdCommand(couponId);
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }
    }
}
