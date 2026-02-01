using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Sample.Shared.Data;
using Blazing.Mvvm.Sample.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blazing.Mvvm.Sample.Shared.ViewModels;

[ViewModelDefinition(Lifetime = ServiceLifetime.Scoped)]
public sealed partial class FetchDataViewModel : ViewModelBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<FetchDataViewModel> _logger;
    private readonly PersistentComponentState? _state;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private PersistingComponentStateSubscription _persistingSubscription;

    [ObservableProperty]
    private IEnumerable<WeatherForecast>? _weatherForecasts;

    public FetchDataViewModel(
        IWeatherService weatherService, 
        ILogger<FetchDataViewModel> logger,
        PersistentComponentState? state = null)
    {
        _weatherService = weatherService;
        _logger = logger;
        _state = state;
    }

    public override async Task OnInitializedAsync()
    {
        if (_state is not null)
        {
            _persistingSubscription = _state.RegisterOnPersisting(PersistWeatherForecasts);

            if (_state.TryTakeFromJson<IEnumerable<WeatherForecast>>(
                nameof(WeatherForecasts), out var restored))
            {
                WeatherForecasts = restored;
                return;
            }
        }

        WeatherForecasts = await _weatherService.GetForecastAsync(_cancellationTokenSource.Token) ?? [];
    }

    private Task PersistWeatherForecasts()
    {
        if (_state is not null)
        {
            _state.PersistAsJson(nameof(WeatherForecasts), WeatherForecasts);
        }
        return Task.CompletedTask;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _logger.LogInformation("Disposing {VMName}.", GetType().Name);
            _persistingSubscription.Dispose();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        base.Dispose(disposing);
    }
}


