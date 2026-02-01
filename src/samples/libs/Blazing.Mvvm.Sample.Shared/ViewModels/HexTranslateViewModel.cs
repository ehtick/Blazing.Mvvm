using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Sample.Shared.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Blazing.Mvvm.Sample.Shared.ViewModels;

[ViewModelDefinition(Key = nameof(HexTranslateViewModel))]
public partial class HexTranslateViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;

    public HexTranslateViewModel(IMessenger messenger)
    {
        _messenger = messenger;
    }

    [RelayCommand]
    public void ResetChildInputs()
        => _messenger.Send(new ResetHexAsciiInputsMessage());
}
