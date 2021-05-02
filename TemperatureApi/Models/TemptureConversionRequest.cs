namespace TemperatureApi.Models
{
    public class TemptureConversionRequest
    {
        public TemperatureUnit ConversionUnit { get; set; }
        public float Value { get; set; }
    }

    public enum TemperatureUnit
    {
        CelsiusToFahrenheit = 1,
        CelsiusToKelvin,
        FahrenheitToCelsius,
        FahrenheitToKelvin,
        KelvinToCelsius,
        KelvinToFahrenheit
    }
}