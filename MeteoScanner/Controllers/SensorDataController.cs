using MeteoScanner.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using MScanner.Data;
using MScanner.Data.Entities;
using MScanner.Models.Models;
using MScanner.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MeteoScanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataRepository _sensorDataRepository;
        private readonly SensorDataHub _sensorDataHub;

        public SensorDataController(ISensorDataRepository sensorDataRepository, SensorDataHub sensorDataHub)
        {
            _sensorDataRepository = sensorDataRepository;
            _sensorDataHub = sensorDataHub;
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
            await _sensorDataHub.SendSensorData(sensorDataModel);
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
            try
            {
                await _sensorDataRepository.DeleteAsync(id);
                await _sensorDataRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the InvalidOperationException (e.g., return a specific error response)
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., log the error, return a generic error response)
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }

}