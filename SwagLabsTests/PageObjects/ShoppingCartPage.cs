using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class ShoppingCartPage : BasePage
{
    private ILocator CheckoutButtonSelector => Page.Result.Locator("//button[@id='checkout']");
    
    public ShoppingCartPage(TestExecutionHooks hooks) : base(hooks) { }
    
    public async Task ClickCheckoutButton()
    {
        await CheckoutButtonSelector.ClickAsync();
    }
}