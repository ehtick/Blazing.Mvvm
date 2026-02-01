using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Sample.Shared.Models.ParentChild;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Blazing.Mvvm.Sample.Shared.ViewModels.ParentChild;

[ViewModelDefinition(Lifetime = ServiceLifetime.Transient)]
public partial class ChildViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _text = "Child";

    [RelayCommand]
    public virtual void Close()
        // tell the parent to close us...
        => WeakReferenceMessenger.Default.Send(new ChildMessage(Text));
}
