using Microsoft.AspNetCore.Components;

namespace POS_Web.Components.Shared;

public partial class NavigationLink
{
    [Parameter]
    public string Href { get; set; } = "#";

    [Parameter]
    public string DisplayValue { get; set; } = string.Empty;
}
