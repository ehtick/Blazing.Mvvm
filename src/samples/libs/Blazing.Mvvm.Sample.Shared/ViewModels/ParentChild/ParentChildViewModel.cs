using Blazing.Mvvm.ComponentModel;
using Blazing.Mvvm.Sample.Shared.Extensions;
using Blazing.Mvvm.Sample.Shared.Models.ParentChild;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Blazing.Mvvm.Sample.Shared.ViewModels.ParentChild;

[ViewModelDefinition(Lifetime = ServiceLifetime.Transient)]
public partial class ParentChildViewModel : RecipientViewModelBase<ChildMessage>
{
    private int _count;

    public readonly Dictionary<string, ChildMetadata> Components = new();

    [ObservableProperty]
    private string? _text = "Welcome to the Parent-Child messaging demo.";

    [RelayCommand]
    public virtual void AddChild()
        => Components.AddChildComponent($"Child #{++_count}");

    // return a numerically sorted set of keys
    public IEnumerable<string> GetSortedKeys()
        => Components.Keys
            .Select(x => x.Split('#')[1])
            .OrderBy(int.Parse)
            .Select(index => $"Child #{index}");

    // inbound message
    public override void Receive(ChildMessage child)
    {
        Components.Remove(child.message);
        NotifyStateChanged();
    }
}
