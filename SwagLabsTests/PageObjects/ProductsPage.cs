using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class ProductsPage : BasePage
{
    private ILocator BackpackAddToCartButtonSelector => Page.Result.Locator("//button[@id='add-to-cart-sauce-labs-backpack']");
    private ILocator BackpackRemoveFromCartButtonSelector => Page.Result.Locator("//button[@id='remove-sauce-labs-backpack']");
    private ILocator ShoppingCartBadgeSelector => Page.Result.Locator("//span[@class='shopping_cart_badge']");
    private ILocator ShoppingCartButtonSelector => Page.Result.Locator("//a[@class='shopping_cart_link']");
    private ILocator BikeLightAddToCartButtonSelector => Page.Result.Locator("//button[@id='add-to-cart-sauce-labs-bike-light']");
    private ILocator BikeLightRemoveFromCartButtonSelector => Page.Result.Locator("//button[@id='remove-sauce-labs-bike-light']");
    private ILocator BackpackItemNameSelector => Page.Result.Locator("//div[@class='inventory_item_name ' and text()= 'Sauce Labs Backpack']");
    private ILocator BackpackDetailsNameSelector => Page.Result.Locator("//div[@class='inventory_details_name large_size' and text()= 'Sauce Labs Backpack']");
    private ILocator BackToProductsButtonSelector => Page.Result.Locator("//button[@id='back-to-products']");
    
    public ProductsPage(TestExecutionHooks hooks) : base(hooks) { }
    
    public async Task ClickBackPackAddToCartButton()
    {
        await BackpackAddToCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickBackPackRemoveFromCartButton()
    {
        await BackpackRemoveFromCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickBikeLightAddToCartButton()
    {
        await BikeLightAddToCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickBackPackItemName()
    {
        await BackpackItemNameSelector.ClickAsync();
    }
    
    public async Task ClickShoppingCartButton()
    {
        await ShoppingCartButtonSelector.ClickAsync();
    }
    
    public async Task AssertBackPackWasAddedToCart()
    {
        await Assertions.Expect(BackpackRemoveFromCartButtonSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertBikeLightWasAddedToCart()
    {
        await Assertions.Expect(BikeLightRemoveFromCartButtonSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertThereIsOneItemAddedToCart()
    {
        await Assertions.Expect(ShoppingCartBadgeSelector).ToHaveTextAsync("1");
    }
    
    public async Task AssertThereAreTwoItemsAddedToCart()
    {
        await Assertions.Expect(ShoppingCartBadgeSelector).ToHaveTextAsync("2");
    }
    
    public async Task AssertBackPackDetailsNameIsVisible()
    {
        await Assertions.Expect(BackpackDetailsNameSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertBackToProductsButtonIsVisible()
    {
        await Assertions.Expect(BackToProductsButtonSelector).ToBeVisibleAsync();
    }
}