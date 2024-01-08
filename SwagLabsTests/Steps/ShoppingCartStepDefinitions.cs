using SwagLabsTests.PageObjects;

namespace SwagLabsTests.Steps;

[Binding]
public class ShoppingCartStepDefinitions
{
    private readonly ShoppingCartPage _shoppingCartPage;
    
    public ShoppingCartStepDefinitions(ShoppingCartPage shoppingCartPage)
    {
        _shoppingCartPage = shoppingCartPage;
    }

    [When(@"I click the Checkout button")]
    public async Task WhenIClickTheCheckoutButton()
    {
        await _shoppingCartPage.ClickCheckoutButton();
    }
}