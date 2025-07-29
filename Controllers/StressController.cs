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

         // GET: api/stress - Tüm kayıtları getir
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var records = _context.StressRecords
                    .OrderByDescending(r => r.Date)
                    .Select(r => new 
                    {
                        id = r.Id,
                        date = r.Date.ToString("yyyy-MM-dd"),
                        stress = r.Stress,
                        emotion = r.Emotion,
                        note = r.Note
                    })
                    .ToList();

                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Sunucu hatası: {ex.Message}");
            }
        }


        
        [HttpPost]
        public IActionResult Add([FromBody] StressRecord record)
        {
            try
            {
                if (record == null || record.Date == default)
                return BadRequest("Geçersiz veri: Tarih boş ya da format hatalı.");

                record.Date = record.Date.Date; // sadece tarih kalsın, saat sıfırlansın
                var existing = _context.StressRecords.FirstOrDefault(r => r.Date.Date == record.Date.Date);
                
                if (existing != null)
                {
                    // Güncelleme
                    existing.Stress = record.Stress;
                    existing.Emotion = record.Emotion;
                    existing.Note = record.Note;
                }
                else
                {
                    // Yeni kayıt
                    _context.StressRecords.Add(record);
                }

                _context.SaveChanges();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Sunucu hatası: {ex.Message}");
            }
        }

        
        [HttpPut("{date}")]
        public IActionResult Update(DateTime date, [FromBody] StressRecord record)
        {
             try
            {
                var existing = _context.StressRecords.FirstOrDefault(r => r.Date.Date == date.Date);
                
                if (existing == null)
                {
                    // Yeni kayıt oluştur
                    var newRecord = new StressRecord
                    {
                        Date = date.Date,
                        Stress = record.Stress,
                        Emotion = record.Emotion,
                        Note = record.Note
                    };
                    _context.StressRecords.Add(newRecord);
                    _context.SaveChanges();
                    return Ok(newRecord);
                }
                else
                {
                    // Mevcut kaydı güncelle
                    existing.Stress = record.Stress;
                    existing.Emotion = record.Emotion;
                    existing.Note = record.Note;
                    _context.SaveChanges();
                    return Ok(existing);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Sunucu hatası: {ex.Message}");
            }
        }

        [HttpDelete("{date}")]
        public IActionResult Delete(DateTime date)
        {
            var record = _context.StressRecords.FirstOrDefault(r => r.Date.Date == date.Date);
            if (record == null)
                return NotFound("Kayıt bulunamadı.");

            _context.StressRecords.Remove(record);
            _context.SaveChanges();
            return Ok("Kayıt silindi.");
    
        }

       


    }

}
