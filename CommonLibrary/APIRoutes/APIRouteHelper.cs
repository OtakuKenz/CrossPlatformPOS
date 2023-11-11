using CommonLibrary.Configuration;

namespace CommonLibrary.APIRoutes;

/// <summary>
/// Helper for API Routes
/// </summary>
public static class APIRouteHelper
{
    /// <summary>
    /// Builds the full URL path for the API
    /// </summary>
    /// <param name="controllerRoute">Route of the controller</param>
    /// <param name="action">Route of specific action</param>
    /// <returns>Full URL path</returns>
    public static string BuildURL(string controllerRoute, string action)
    {
        return $"{SharedConfiguration.APIBase}/{controllerRoute}/{action}";
    }
}