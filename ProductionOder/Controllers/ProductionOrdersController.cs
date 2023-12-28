using Microsoft.AspNetCore.Mvc;
using ProductionOrder.Data;
using ProductionOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace ProductionOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionOrdersController : Controller
    {
       
        private readonly ProductionOrderDbContext _ProductionOderDbContext;
        public ProductionOrdersController(ProductionOrderDbContext ProductionOderDbContext)
        {
            _ProductionOderDbContext = ProductionOderDbContext;
        }

        [HttpPost(Name = "NewProductionOrder")]
        public async Task<IActionResult> AddData([FromBody] ProductionOrders dataRequest)
        {
            await _ProductionOderDbContext.ProductionOrders.AddAsync(dataRequest);
            await _ProductionOderDbContext.SaveChangesAsync();
            return Ok(dataRequest);

        }


        //view all data
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var datas = await _ProductionOderDbContext.ProductionOrders.OrderBy(n => n.ProductionOrderID).ToListAsync();
            return Ok(datas);
        }


        // 
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDataId([FromRoute] Guid id)
        {
            var data = await _ProductionOderDbContext.ProductionOrders.FirstOrDefaultAsync(x => x.ProductionOrderID == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
