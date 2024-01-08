using SwagLabsTests.PageObjects;

namespace SwagLabsTests.Steps;

[Binding]
public class CheckoutStepDefinitions
{
    private readonly CheckoutPage _checkoutPage;
    
    public CheckoutStepDefinitions(CheckoutPage checkoutPage)
    {
        _checkoutPage = checkoutPage;
    }

    [When(@"I fill in the checkout form with my info: '(.*)', '(.*)', '(.*)'")]
    public async Task WhenIFillInTheCheckoutFormWithMyInfo(string firstName, string lastName, string zipCode)
    {
        await _checkoutPage.FillInFirstNameInput(firstName);
        await _checkoutPage.FillInLastNameInput(lastName);
        await _checkoutPage.FillInZipCodeInput(zipCode);
    }

    [When(@"I click the Continue button")]
    public async Task WhenIClickTheContinueButton()
    {
        await _checkoutPage.ClickContinueCheckoutButton();
    }

    [When(@"I click the Finish button on Checkout overview page")]
    public async Task WhenIClickTheFinishButtonOnCheckoutOverviewPage()
    {
        await _checkoutPage.ClickFinishCheckoutButton();
    }

    [Then(@"I have finished my shopping")]
    public async Task ThenIHaveFinishedMyShopping()
    {
        await _checkoutPage.AssertCompletedOrderMessageIsVisible();
    }
}