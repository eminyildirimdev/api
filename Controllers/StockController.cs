using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
     
        private readonly AppDbContext _context;
        public StockController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
       
    }
}