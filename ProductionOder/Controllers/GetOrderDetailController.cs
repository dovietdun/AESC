using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionOrder.Data;
using ProductionOrder.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductionOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOrderDetailController : ControllerBase
    {

        private readonly ProductionOrderDbContext _ProductionOderDbContext;
        public GetOrderDetailController(ProductionOrderDbContext dBContext)
        {
            _ProductionOderDbContext = dBContext;
        }
        // GET: api/<GetOrderDetail>
        //view all data
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            var datas = await _ProductionOderDbContext.OrderLines.OrderBy(n => n.OrderLineID).ToListAsync();
            return Ok(datas);
        }
        //view by id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDataId([FromRoute] Guid id)
        {
            var data = await _ProductionOderDbContext.OrderLines.FirstOrDefaultAsync(x => x.OrderID == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }



    }
}
