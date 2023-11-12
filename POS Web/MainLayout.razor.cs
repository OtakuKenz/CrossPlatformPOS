using BlazorBootstrap;

namespace POS_Web;

public partial class MainLayout
{

    Sidebar sidebar = null!;
    IEnumerable<NavItem> navItems = null!;

    private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
    {
        navItems ??= GetNavItems();

        return await Task.FromResult(request.ApplyTo(navItems));
    }

    private IEnumerable<NavItem> GetNavItems()
    {
        navItems = new List<NavItem>
        {
            new() { Id = "1", Href = "/items", IconName = IconName.HouseDoorFill, Text = "Item"},
        };

        return navItems;
    }
}
