using Blazing.Common;
using Microsoft.AspNetCore.Components;

namespace Blazing.Mvvm.Sample.Shared.Components;

public partial class BootstrapCard : ComponentControlBase
{
    private const string DEFAULT_BASE_CLASSES = "card";

    /// <summary>
    /// Optional card header content.
    /// </summary>
    [Parameter]
    public RenderFragment? Header { get; set; }

    /// <summary>
    /// Optional card body content. If not set, uses ChildContent.
    /// </summary>
    [Parameter]
    public RenderFragment? Body { get; set; }

    /// <summary>
    /// Optional card footer content.
    /// </summary>
    [Parameter]
    public RenderFragment? Footer { get; set; }

    /// <summary>
    /// Builds the CSS classes for the button 
    /// </summary>
    /// <returns></returns>
    private string GetClasses()
        => CssBuilder
            .Default(Class ?? DEFAULT_BASE_CLASSES)
            .AddClass(AdditionalClasses!, () => !string.IsNullOrEmpty(AdditionalClasses))
            .Build();
}
