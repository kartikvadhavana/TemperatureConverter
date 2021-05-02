using Microsoft.Extensions.Logging;
using System;
using TemperatureApi.Models;

namespace TemperatureApi.Services
{
    public class TemperatureConversionService : ITemperatureConversionService
    {
        private readonly ILogger _logger;

        public TemperatureConversionService(ILogger<TemperatureConversionService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Converts input temperature value to new value unit based on the given conversion unit input
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public double ConvertTemperature(TemptureConversionRequest request)
        {
            try
            {
                _logger.LogInformation($"Request object {request}");

                return request.ConversionUnit switch
                {
                    TemperatureUnit.CelsiusToFahrenheit => (1.8 * request.Value) + 32,
                    TemperatureUnit.CelsiusToKelvin => request.Value + 273.15,
                    TemperatureUnit.FahrenheitToCelsius => (request.Value - 32) / 1.8,
                    TemperatureUnit.FahrenheitToKelvin => ((request.Value - 32) / 1.8) + 273.15,
                    TemperatureUnit.KelvinToCelsius => request.Value - 273.15,
                    TemperatureUnit.KelvinToFahrenheit => (request.Value - 273.15) * 1.8 + 32,
                    _ => request.Value,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while converting temperature. Error - {ex.Message}\n {ex.StackTrace}");
                throw;
            }
        }
    }
}
