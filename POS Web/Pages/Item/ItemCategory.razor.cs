using System.Net.Http.Json;
using BlazorBootstrap;
using CommonLibrary.APIRoutes.Item;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace POS_Web.Pages.Item;

public partial class ItemCategory : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; } = null!;

    [Inject]
    private ToastService ToastService { get; set; } = null!;

    private CommonLibrary.Model.Item.ItemCategory ItemCategoryModel { get; set; } = new();

    private bool IsSaving = false;

    private EditContext ItemCategoryEditContext = default!;

    protected override void OnInitialized()
    {
        ItemCategoryEditContext = new(ItemCategoryModel);
    }


    private async void OnValidFormSubmit()
    {
        if (!IsSaving)
        {
            if (ItemCategoryEditContext.Validate())
            {
                IsSaving = true;
                StateHasChanged();
                var result = await HttpClient.PostAsJsonAsync(ItemCategoryRoute.CreateItemCategory_FullPath, ItemCategoryModel);
                if (result.IsSuccessStatusCode)
                {
                    ToastService.Notify(new(ToastType.Success, title: "Success", message: $"Item Category: {ItemCategoryModel.Name} saved."));
                    ItemCategoryModel = new();
                }
                else
                {
                    ToastService.Notify(new(ToastType.Warning, title: "Error", message: $"{await result.Content.ReadAsStringAsync()}"));
                }
                IsSaving = false;
                StateHasChanged();
            }
        }
    }

    private Modal modal = default!;

    private async Task OnShowModalClick()
    {
        await modal.ShowAsync();
    }

    private async Task OnHideModalClick()
    {
        ItemCategoryModel = new();
        await modal.HideAsync();
    }
}