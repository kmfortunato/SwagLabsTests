using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class CheckoutPage : BasePage
{
    private ILocator FirstNameInputSelector => Page.Result.Locator("//input[@id='first-name']");
    private ILocator LastNameInputSelector => Page.Result.Locator("//input[@id='last-name']");
    private ILocator ZipCodeInputSelector => Page.Result.Locator("//input[@id='postal-code']");
    private ILocator ContinueCheckoutButtonSelector => Page.Result.Locator("//input[@id='continue']");
    private ILocator FinishCheckoutButtonSelector => Page.Result.Locator("//button[@id='finish']");
    private ILocator CompletedOrderMessageSelector => Page.Result.Locator("//h2[@class='complete-header' and text()= 'Thank you for your order!']");
    
    public CheckoutPage(TestExecutionHooks hooks) : base(hooks) { }
    
    public async Task ClickContinueCheckoutButton()
    {
        await ContinueCheckoutButtonSelector.ClickAsync();
    }
    
    public async Task ClickFinishCheckoutButton()
    {
        await FinishCheckoutButtonSelector.ClickAsync();
    }
    
    public async Task FillInFirstNameInput(string firstsName)
    {
        await FirstNameInputSelector.FillAsync(firstsName);
    }
    
    public async Task FillInLastNameInput(string lastName)
    {
        await LastNameInputSelector.FillAsync(lastName);
    }
    
    public async Task FillInZipCodeInput(string zipCode)
    {
        await ZipCodeInputSelector.FillAsync(zipCode);
    }
    
    public async Task AssertCompletedOrderMessageIsVisible()
    {
        await Assertions.Expect(CompletedOrderMessageSelector).ToBeVisibleAsync();
    }
}