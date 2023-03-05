using Microsoft.AspNetCore.Mvc;
using MScanner.Data;
using MScanner.Data.Entities;
using MScanner.Models.Models;
using MScanner.Repository.Api;
using System.Collections.Generic;
using System.Linq;

namespace MeteoScanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataRepository _sensorDataRepository;

        public SensorDataController(ISensorDataRepository sensorDataRepository)
        {
            _sensorDataRepository = sensorDataRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDataModel>>> GetSensorData()
        {
            var sensorData = await _sensorDataRepository.GetAllAsync();
            return Ok(sensorData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorDataModel>> GetSensorData(int id)
        {
            var sensorData = await _sensorDataRepository.GetByIdAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return Ok(sensorData);
        }

        [HttpPost]
        public async Task<ActionResult<SensorDataModel>> PostSensorData(SensorDataModel sensorDataModel)
        {
            var createdSensorData = await _sensorDataRepository.AddAsync(sensorDataModel);
            return CreatedAtAction(nameof(GetSensorData), new { id = createdSensorData.Id }, createdSensorData);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(int id, SensorDataModel sensorDataModel)
        {
            var updatedSensorData = await _sensorDataRepository.UpdateAsync(id, sensorDataModel);

            if (updatedSensorData == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorData(int id)
        {
            await _sensorDataRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}