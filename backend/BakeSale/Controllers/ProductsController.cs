﻿using Microsoft.AspNetCore.Mvc;
using BakeSale.Models;
using BakeSale.Repositories;

namespace BakeSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repo;

        public ProductsController(IProductsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repo.GetAllAsync();
            
            if (products is null)
            {
                return NotFound();
            }
            
            return Ok(products);
        }
    }
}
