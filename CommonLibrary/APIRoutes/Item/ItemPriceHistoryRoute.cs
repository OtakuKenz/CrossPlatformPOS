using static CommonLibrary.APIRoutes.APIRouteHelper;

namespace CommonLibrary.APIRoutes.Item;

public static class ItemPriceHistoryRoute
{
    public const string ControllerRoute = "api/itemPriceHistory";

    /// <summary>
    /// Get item price history<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public const string GetItemPriceHistory = "getHistory";

    /// <summary>
    /// Get item price history in full path<br/>
    /// Request type: <c>GET</c>
    /// </summary>
    public static string GetItemPriceHistory_FullPath { get { return BuildURL(ControllerRoute, GetItemPriceHistory); } }

}
