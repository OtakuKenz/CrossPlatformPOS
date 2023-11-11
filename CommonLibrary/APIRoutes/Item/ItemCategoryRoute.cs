using static CommonLibrary.APIRoutes.APIRouteHelper;

namespace CommonLibrary.APIRoutes.Item;

public class ItemCategoryRoute
{
    public const string ControllerRoute = "api/itemCategory";

    /// <summary>
    /// Get all item categories that are active<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public const string GetItemCategories = "getCategories";

    /// <summary>
    /// Get all item categories that are active in full path<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public static string GetItemCategories_FullPath { get { return BuildURL(ControllerRoute, GetItemCategories); } }

    /// <summary>
    /// Get specific item category based on ID<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public const string GetItemCategory = "getCategory";

    /// <summary>
    /// Get specific item category based on ID in full path<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public static string GetItemCategory_FullPath { get { return BuildURL(ControllerRoute, GetItemCategory); } }

    /// <summary>
    /// Create new item category<br/>
    /// Request type: <c>POST</c>
    /// </summary>
    public const string CreateItemCategory = "addItem";

    /// <summary>
    /// Create new item category in full path<br/>
    /// Request type: <c>POST</c>
    /// </summary>
    public static string CreateItemCategory_FullPath { get { return BuildURL(ControllerRoute, CreateItemCategory); } }

    /// <summary>
    /// Update item category<br/>
    /// Request type: <c>PUT</c>
    /// </summary>
    public const string UpdateItemCategory = "updateItem";

    /// <summary>
    /// Update item category in full path<br/>
    /// Request type: <c>PUT</c>
    /// </summary>
    public static string UpdateItemCategory_FullPath { get { return BuildURL(ControllerRoute, UpdateItemCategory); } }

    /// <summary>
    /// Delete item category<br/>
    /// Request type: <c>Delete</c>
    /// </summary>
    public const string DeleteItemCategory = "deleteItem";

    /// <summary>
    /// Delete item category in full path<br/>
    /// Request type: <c>Delete</c>
    /// </summary>
    public static string DeleteItemCategory_FullPath { get { return BuildURL(ControllerRoute, DeleteItemCategory); } }
}
