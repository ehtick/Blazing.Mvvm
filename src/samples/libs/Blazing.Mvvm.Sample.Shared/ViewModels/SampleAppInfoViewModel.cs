using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Components;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Blazing.Mvvm.Sample.Shared.ViewModels;

[ViewModelDefinition(Lifetime = ServiceLifetime.Scoped)]
public sealed partial class SampleAppInfoViewModel : ViewModelBase
{
    private readonly IMvvmNavigationManager _mvvmNavigationManager;
    private readonly NavigationManager _navigationManager;

    public SampleAppInfoViewModel(IMvvmNavigationManager mvvmNavigationManager, NavigationManager navigationManager)
    {
        _mvvmNavigationManager = mvvmNavigationManager;
        _navigationManager = navigationManager;
    }

    [RelayCommand]
    private void Navigation(string? page)
    {
        if (string.IsNullOrWhiteSpace(page))
            return;

        switch (page.ToLowerInvariant())
        {
            case "relaycommands":
                _navigationManager.NavigateTo("/relaycommands");
                break;
            case "users":
                _mvvmNavigationManager.NavigateTo<UsersViewModel>();
                break;
            case "test":
                _mvvmNavigationManager.NavigateTo<ITestNavigationViewModel>();
                break;
            case "keyedtest":
                _mvvmNavigationManager.NavigateTo(nameof(TestKeyedNavigationViewModel));
                break;
            case "hextranslate":
                _mvvmNavigationManager.NavigateTo<HexTranslateViewModel>();
                break;
            case "form":
                _mvvmNavigationManager.NavigateTo<EditContactViewModel>();
                break;
            case "fetchdata":
                _mvvmNavigationManager.NavigateTo<FetchDataViewModel>();
                break;
        }
    }
}
