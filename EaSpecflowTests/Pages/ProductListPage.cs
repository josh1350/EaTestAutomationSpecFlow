using System.Threading.Tasks;
using Microsoft.Playwright;



namespace EaSpecflowTests.Pages;

public interface IProductListPage
{
    Task CreateProductAsync();
    Task ClickProductFromList(string name);
    ILocator IsProductCreated(string product);
}

public class ProductListPage : IProductListPage
{
    private readonly IPage _page;

    public ProductListPage(IPage page)
    {
        _page = page;
    }

    private ILocator _lnkProductList => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = "Product" });
    private ILocator _lnkCreate => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = "Create" });

    public async Task CreateProductAsync()
    {
        await _lnkProductList.ClickAsync();
        await _lnkCreate.ClickAsync();
    }

    public async Task ClickProductFromList(string name)
    {
        await _page.GetByRole(AriaRole.Row, new PageGetByRoleOptions() { Name = name })
            .GetByRole(AriaRole.Link, new LocatorGetByRoleOptions() { Name = "Details" }).ClickAsync();
    }

    public ILocator IsProductCreated(string product)
    {
        return _page.GetByText(product, new PageGetByTextOptions() { Exact = true});
    }
}