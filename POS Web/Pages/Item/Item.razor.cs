using System.Net.Http.Json;
using BlazorBootstrap;
using CommonLibrary.APIRoutes.Item;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace POS_Web.Pages.Item;

public partial class Item : ComponentBase
{
    [Inject]
    protected HttpClient HttpClient { get; set; } = null!;

    protected List<CommonLibrary.Model.Item.ItemCategory>? ItemCategoryList { get; set; }

    protected CommonLibrary.Model.Item.Item ItemModel { get; set; } = new();

    protected bool IsLoading = false;

    protected bool IsSaving { get; set; } = false;

    protected Modal Modal { get; set; } = default!;

    [Inject]
    protected PreloadService PreloadService { get; set; } = null!;

    [Inject]
    private ToastService ToastService { get; set; } = null!;

    protected bool IsFetchingAPIData = false;

    private EditContext ItemEditContext = default!;



    protected override async Task OnInitializedAsync()
    {
        ItemEditContext = new EditContext(ItemModel);
        await LoadItemCategories();
    }

    public async Task OnValidFormSubmit()
    {
        if (!IsSaving && ItemEditContext.Validate())
        {
            IsSaving = true;
            try
            {
                ItemModel.ItemCategory = ItemCategoryList!.First(e => e.ItemCategoryId == ItemModel.ItemCategoryId);
                HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync(ItemRoute.CreateItem_FullPath, ItemModel);
                if (responseMessage.IsSuccessStatusCode)
                {
                    ToastService.Notify(new(ToastType.Success, title: "Added", message: $"Added Item: {ItemModel.Name}"));
                    ItemModel = new();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                ToastService.Notify(new(ToastType.Warning, title: "Connection Failed", message: $"Failed to connect to server."));
                Console.WriteLine($"Failed to connect to server. Error: {ex.Message}");
            }
            IsSaving = false;
        }
    }

    public async Task LoadItemCategories()
    {
        IsLoading = true;
        ItemCategoryList = await HttpClient.GetFromJsonAsync<List<CommonLibrary.Model.Item.ItemCategory>>(ItemCategoryRoute.GetItemCategories_FullPath);
        IsLoading = false;
    }

    public async Task ShowAddItemCategory()
    {
        await Modal.ShowAsync<ItemCategory>(title: "Add Item Category");
    }
}