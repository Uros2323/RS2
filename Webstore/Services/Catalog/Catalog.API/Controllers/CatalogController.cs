﻿using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        IProductRepository _repository;
        
        public CatalogController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }
    }
}
