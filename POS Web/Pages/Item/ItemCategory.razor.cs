using System.Net.Http.Json;
using CommonLibrary.APIRoutes.Item;
using Microsoft.AspNetCore.Components;

namespace POS_Web.Pages.Item;

public partial class ItemCategory
{
    [Inject]
    public HttpClient HttpClient { get; set; } = null!;

    public CommonLibrary.Model.Item.ItemCategory ItemCategoryModel { get; set; } = new();

    public async void OnValidFormSubmit()
    {
        try
        {
            var result = await HttpClient.PostAsJsonAsync(ItemCategoryRoute.CreateItemCategory_FullPath, ItemCategoryModel);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Submitted");
            }
            else
            {
                Console.WriteLine("Failed");
                Console.WriteLine(result.Content.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
