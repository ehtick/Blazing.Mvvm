using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Blazing.Mvvm.Sample.Shared.ViewModels;

[ViewModelDefinition<ITestNavigationViewModel>(Lifetime = ServiceLifetime.Scoped)]
public sealed class TestNavigationViewModel(IMvvmNavigationManager mvvmNavigationManager, NavigationManager navigationManager)
    : TestNavigationBaseViewModel(mvvmNavigationManager, navigationManager)
{ /* skipped */ }