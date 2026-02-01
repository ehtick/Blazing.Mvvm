using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Sample.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Threading;

namespace Blazing.Mvvm.Sample.Shared.ViewModels;

public sealed partial class EditContactViewModel : ViewModelBase
{
    private readonly ILogger<EditContactViewModel> _logger;

    [ObservableProperty]
    private ContactInfo _contact = new();

    public EditContactViewModel(ILogger<EditContactViewModel> logger)
    {
        _logger = logger;
        Contact.PropertyChanged += ContactOnPropertyChanged;
    }

    [RelayCommand]
    private void ClearForm()
        => Contact = new ContactInfo();

    [RelayCommand]
    private void Save()
        => _logger.LogInformation("Form is valid and submitted!");

    private void ContactOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        => NotifyStateChanged();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _logger.LogInformation("Disposing {VMName}.", GetType().Name);
            Contact.PropertyChanged -= ContactOnPropertyChanged;
        }

        base.Dispose(disposing);
    }
}
