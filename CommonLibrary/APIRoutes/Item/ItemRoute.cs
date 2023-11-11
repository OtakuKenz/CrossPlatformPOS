using static CommonLibrary.APIRoutes.APIRouteHelper;

namespace CommonLibrary.APIRoutes.Item;

public static class ItemRoute
{
    public const string ControllerRoute = "api/item";

    /// <summary>
    /// Get all items that are active<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public const string GetItems = "getItems";

    /// <summary>
    /// Get all items that are active in full path<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public static string GetItems_FullPath { get { return BuildURL(ControllerRoute, GetItems); } }

    /// <summary>
    /// Get specific item based on ID<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public const string GetItem = "getItem";

    /// <summary>
    /// Get specific item based on ID<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public static string GetItem_FullPath { get { return BuildURL(ControllerRoute, GetItem); } }

    /// <summary>
    /// Create new item<br/>
    /// Request type: <c>POST</c>
    /// </summary>
    public const string CreateItem = "addItem";

    /// <summary>
    /// Create new item<br/>
    /// Request type: <c>POST</c>
    /// </summary>
    public static string CreateItem_FullPath { get { return BuildURL(ControllerRoute, CreateItem); } }

    /// <summary>
    /// Update item<br/>
    /// Request type: <c>PUT</c>
    /// </summary>
    public const string UpdateItem = "updateItem";

    /// <summary>
    /// Update item<br/>
    /// Request type: <c>PUT</c>
    /// </summary>
    public static string UpdateItem_FullPath { get { return BuildURL(ControllerRoute, UpdateItem); } }

    /// <summary>
    /// Delete item<br/>
    /// Request type: <c>Delete</c>
    /// </summary>
    public const string DeleteItem = "deleteItem";

    /// <summary>
    /// Delete item<br/>
    /// Request type: <c>Delete</c>
    /// </summary>
    public static string DeleteItem_FullPath { get { return BuildURL(ControllerRoute, DeleteItem); } }
}
