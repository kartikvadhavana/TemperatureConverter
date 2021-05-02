using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TemperatureApi.Models;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;
        private readonly ITemperatureConversionService _temperatureConversionService;

        public TemperatureController(ITemperatureConversionService temperatureConversionService, ILogger<TemperatureController> logger)
        {
            _temperatureConversionService = temperatureConversionService;
            _logger = logger;
        }


        /// <summary>
        /// Converts temperature value between Celsius, Fahrenheit, and Kelvin
        /// </summary>
        /// <param name="request">
        /// ConversionUnit = Value between 1 to 6 
        /// Value = Temperature value to be converted
        /// </param>
        /// <returns>converted temperature value</returns>
        [HttpGet("convert")]
        public IActionResult Get([FromQuery]TemptureConversionRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var convertedValue = _temperatureConversionService.ConvertTemperature(request);
                return Ok(convertedValue);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while converting temperature. Error - {ex.Message}\n {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
