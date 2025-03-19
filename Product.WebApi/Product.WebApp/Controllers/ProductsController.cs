using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Application.Features.ProductFeatures.DTOs;
using Product.Application.Interfaces;

namespace Product.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IProductApiClient _productApiClient;
        private readonly IMapper _mapper;

        public ProductsController(IApplicationDbContext context,
            IProductApiClient productApiClient,
            IMapper mapper)
        {
            _context = context;
            _productApiClient = productApiClient;
            _mapper = mapper;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_productApiClient.GetAll());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var product = _productApiClient.GetById(id);
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price")] CreateProductDto product)
        {
            if (ModelState.IsValid)
            {
                _productApiClient.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var productDetails = _productApiClient.GetById(id);
            if (productDetails == null)
            {
                return NotFound();
            }
            var productUpdate = _mapper.Map<UpdateProductDto>(productDetails);
            
            return View(productUpdate);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Price,Id")] UpdateProductDto product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productApiClient.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
           
            var product = _productApiClient.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _productApiClient.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        
    }
}
