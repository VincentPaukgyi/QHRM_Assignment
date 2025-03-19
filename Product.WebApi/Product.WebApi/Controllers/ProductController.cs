using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.ProductFeatures.Commands;
using Product.Application.Features.ProductFeatures.DTOs;
using Product.Application.Features.ProductFeatures.Queries;

namespace Product.WebApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto product)
        {
            var command = _mapper.Map<CreateProductCommand>(product);
            await Mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetAllProductsQuery());
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await Mediator.Send(new GetProductByIdQuery { Id = id });
            var productDto = _mapper.Map<ProductDetailsDto>(product);
            return Ok(productDto);
        }
        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Product Entity.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto product)
        {
            var command = _mapper.Map<UpdateProductCommand>(product);
            return Ok(await Mediator.Send(command));
        }
    }
}
