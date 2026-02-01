using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace Blazing.Mvvm.Sample.Shared.Information;

public partial class SampleAppInfo : ComponentBase
{
    [CascadingParameter]
    public IViewModelBase? ViewModel { get; set; }

    private void NavigateToPage(string page)
    {
        if (ViewModel is ISampleAppInfoViewModel vm)
        {
            vm.NavigationCommand.Execute(page);
        }
    }
}

public interface ISampleAppInfoViewModel : IViewModelBase
{
    IRelayCommand<string> NavigationCommand { get; }
}
