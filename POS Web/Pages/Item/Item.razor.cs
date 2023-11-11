using System.Net.Http.Json;
using CommonLibrary.APIRoutes.Item;
using Microsoft.AspNetCore.Components;

namespace POS_Web.Pages.Item;

public partial class Item
{
    [Inject]
    public HttpClient HttpClient { get; set; } = null!;

    public List<CommonLibrary.Model.Item.ItemCategory>? ItemCategoryList { get; set; }

    public CommonLibrary.Model.Item.Item ItemModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        ItemCategoryList = await HttpClient.GetFromJsonAsync<List<CommonLibrary.Model.Item.ItemCategory>>(ItemCategoryRoute.GetItemCategories_FullPath);
    }

    public async void OnValidFormSubmit()
    {
        try
        {
            ItemModel.ItemCategory = ItemCategoryList!.First(e => e.ItemCategoryId == ItemModel.ItemCategoryId);
            await HttpClient.PostAsJsonAsync(ItemRoute.CreateItem_FullPath, ItemModel);
            Console.WriteLine("Submitted");
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to connect to API");
        }
    }

}