using EasyShopping.Product.Application.CQRS.Commands;
using EasyShopping.Product.Application.CQRS.Queries;
using EasyShopping.Product.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                FindProductByIdQuery query = new FindProductByIdQuery(id);
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }            
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                FindAllProductsQuery query = new FindAllProductsQuery();
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPost("find-all-paged")]
        public async Task<IActionResult> FindAllPaged([FromBody]FilterViewModel filter)
        {
            try
            {
                FindAllProductsPagedQuery query = new FindAllProductsPagedQuery(filter);
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]ProductViewModel model)
        {
            try
            {
                CreateProductCommand command = new CreateProductCommand(model);
                var result = await _mediator.Send(command); 
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]ProductViewModel model)
        {
            try
            {
                UpdateProductCommand command = new UpdateProductCommand(model);
                var result = await _mediator.Send(command); 
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                DeleteProductByIdCommand command = new DeleteProductByIdCommand(id);
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
