using Blazing.SubpathHosting.Server.Models;

namespace Blazing.SubpathHosting.Server.Data;

/// <summary>
/// Provides weather forecast data retrieval services.
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Asynchronously retrieves a collection of weather forecasts.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="WeatherForecast"/> objects, or <c>null</c> if no data is available.</returns>
    Task<IEnumerable<WeatherForecast>?> GetForecastAsync(CancellationToken cancellationToken = default);
}
