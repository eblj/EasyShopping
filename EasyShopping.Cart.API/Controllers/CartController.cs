using EasyShopping.Cart.Application.CQRS.Commands;
using EasyShopping.Cart.Application.CQRS.Queries;
using EasyShopping.Cart.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopping.Cart.API.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("find-by-user-id/{userId}")]
        public async Task<IActionResult> FindByUserId(Guid userId)
        {
            try
            {
                FindCartByUserIdQuery query = new FindCartByUserIdQuery(userId);
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPost("create-or-update")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CartViewModel model)
        {
            try
            {
                CreateOrUpdateCartCommand command = new CreateOrUpdateCartCommand(model);
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPut("remove-item/{cartDetailsId}")]
        public async Task<IActionResult> RemoveFrom(Guid cartDetailsId)
        {
            try
            {
                RemoveFromCartCommand command = new RemoveFromCartCommand(cartDetailsId);
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> Clear(Guid userId)
        {
            try
            {
                ClearCartCommand command = new ClearCartCommand(userId);
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
