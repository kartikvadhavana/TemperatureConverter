using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Services
{
    public interface ITemperatureConversionService
    {
        double ConvertTemperature(TemptureConversionRequest request);
    }
}
