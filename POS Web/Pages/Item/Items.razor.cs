using System.Net.Http.Json;
using CommonLibrary.Model.Item;
using CommonLibrary.APIRoutes.Item;
using Microsoft.AspNetCore.Components;

namespace POS_Web.Pages.Item;

public partial class Items : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; } = null!;

    protected List<CommonLibrary.Model.Item.Item>? ListOfItems { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ListOfItems = await HttpClient.GetFromJsonAsync<List<CommonLibrary.Model.Item.Item>>(ItemRoute.GetItems_FullPath);
    }
}