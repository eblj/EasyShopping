using EasyShopping.Product.Application.CQRS.Commands;
using EasyShopping.Product.Application.CQRS.Queries;
using EasyShopping.Product.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                FindCategoryByIdQuery query = new FindCategoryByIdQuery(id);
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
                FindAllCategoriesQuery query = new FindAllCategoriesQuery();
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPost("find-all-paged")]
        public async Task<IActionResult> FindAllPaged([FromBody] FilterViewModel filter)
        {
            try
            {
                FindAllCategoriesPagedQuery query = new FindAllCategoriesPagedQuery(filter);
                var result = await _mediator.Send(query);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryViewModel model)
        {
            try
            {
                CreateCategoryCommand command = new CreateCategoryCommand(model);
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Sorry, but an error occurred: {0}", ex.ToString()));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategoryViewModel model)
        {
            try
            {
                UpdateCategoryCommand command = new UpdateCategoryCommand(model);
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
                DeleteCategoryByIdCommand command = new DeleteCategoryByIdCommand(id);
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
