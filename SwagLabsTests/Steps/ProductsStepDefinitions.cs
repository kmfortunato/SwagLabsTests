using SwagLabsTests.PageObjects;

namespace SwagLabsTests.Steps;

[Binding]
public sealed class ProductsStepDefinitions
{
    private readonly ProductsPage _productsPage;
    
    public ProductsStepDefinitions(ProductsPage productsPage)
    {
        _productsPage = productsPage;
    }

    [Given(@"I added an item to the cart")]
    public async Task GivenIAddedAnItemToTheCart()
    {
        await _productsPage.ClickBackPackAddToCartButton();
    }
    
    [Given(@"I clicked to see my shopping cart")]
    public async Task GivenIClickedToSeeMyShoppingCart()
    {
        await _productsPage.ClickShoppingCartButton();
    }
    
    [When(@"I click to add the Backpack to the cart")]
    public async Task WhenIClickToAddTheBackpackToTheCart()
    {
        await _productsPage.ClickBackPackAddToCartButton();
    }
    
    [When(@"I click to add the Bike Light to the cart")]
    public async Task WhenIClickToAddTheBikeLightToTheCart()
    {
        await _productsPage.ClickBikeLightAddToCartButton();
        await _productsPage.AssertBikeLightWasAddedToCart();
        await _productsPage.AssertThereAreTwoItemsAddedToCart();
    }
    
    [When(@"I click to remove the Backpack from the cart")]
    public async Task WhenIClickToRemoveTheBackpackFromTheCart()
    {
        await _productsPage.ClickBackPackRemoveFromCartButton();
    }

    [Then(@"The Backpack is added to the shopping cart")]
    public async Task ThenTheBackpackIsAddedToTheShoppingCart()
    {
        await _productsPage.AssertBackPackWasAddedToCart();
        await _productsPage.AssertThereIsOneItemAddedToCart();
    }

    [Then(@"The items in the shopping cart are updated")]
    public async Task ThenTheItemsInTheShoppingCartAreUpdated()
    {
        await _productsPage.AssertThereIsOneItemAddedToCart();
    }

    [When(@"I click the Backpack name at the products page")]
    public async Task WhenIClickTheBackpackNameAtTheProductsPage()
    {
        await _productsPage.ClickBackPackItemName();
    }

    [Then(@"I am redirected to the Backpack details page")]
    public async Task ThenIAmRedirectedToTheBackpackDetailsPage()
    {
        await _productsPage.AssertBackPackDetailsNameIsVisible();
        await _productsPage.AssertBackToProductsButtonIsVisible();
    }
}