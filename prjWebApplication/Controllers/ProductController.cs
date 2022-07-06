using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductController(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        [HttpGet("{id}")]
        public Product GetProducts(int id)
        {
            return _context.Products.Find(id);
        }

        [Route("category/{id}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return _context.Products.Where(p => p.CategoryId == id);
        }

        [Route("supplier/{id:int}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsBySupplierId(int id)
        {
            return _context.Products.Where(p => p.SupplierId == id);
        }
    }
}
