using Hostel.Business.Abstract;
using Hostel.Business.Concrete;
using Hostel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HostelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostelsController : ControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelsController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        /// <summary>
        /// Tüm hostelleri getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hostels = await _hostelService.GetAllHostels();
            return Ok(hostels); // 200+data
        }

        /// <summary>
        /// Id'ye göre hosteli getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] // api/hostels/GetHostelById/1
        public async Task<IActionResult> GetHostelById(int id)
        {
            var hostel = await _hostelService.GetHostelById(id);
            if (hostel != null)
            {
                return Ok(hostel); // 200+data
            }
            return NotFound(); // 404
        }

        [HttpGet]
        [Route("[action]/{name}")] // api/hostels/GetHostelByName/1
        public async Task<IActionResult> GetHostelByName(string name)
        {
            var hostel = await _hostelService.GetHostelByName(name);
            if (hostel != null)
            {
                return Ok(hostel); // 200+data
            }
            return NotFound(); // 404
        }

        /// <summary>
        /// Hostel oluşturur
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHostel([FromBody] HostelModel hostel)
        {
            var createdHostel = await _hostelService.CreateHostel(hostel);
            return CreatedAtAction("Get", new { id = createdHostel.Id }, createdHostel);
        }

        /// <summary>
        /// Hostel günceller
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateHostel([FromBody] HostelModel hostel)
        {
            if (await _hostelService.GetHostelById(hostel.Id) != null)
            {
                return Ok(await _hostelService.UpdateHostel(hostel));
            }
            return NotFound();
        }

        /// <summary>
        /// Hostel siler
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHostel(int id)
        {
            if (await _hostelService.GetHostelById(id) != null)
            {
                await _hostelService.DeleteHostel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
