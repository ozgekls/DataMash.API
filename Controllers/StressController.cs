using Microsoft.AspNetCore.Mvc;
using DataMash.API.Data;
using DataMash.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DataMash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StressController : ControllerBase
    {
        private readonly DataMashContext _context;

        public StressController(DataMashContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] StressRecord record)
        {
            _context.StressRecords.Add(record);
            await _context.SaveChangesAsync();
            return Ok(record);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _context.StressRecords.ToListAsync();
            return Ok(records);
        }
    }
}
