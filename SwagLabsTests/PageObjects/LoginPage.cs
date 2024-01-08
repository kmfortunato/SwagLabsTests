using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class LoginPage : BasePage
{
    private ILocator UserNameInputSelector => Page.Result.Locator("//input[@id='user-name']");
    private ILocator PasswordInputSelector => Page.Result.Locator("//input[@id='password']");
    private ILocator LoginButtonSelector => Page.Result.Locator("//input[@id='login-button']");
    private ILocator ProductsPageTitleSelector => Page.Result.Locator("//span[@class='title' and text()= 'Products']");
    
    public LoginPage(TestExecutionHooks hooks) : base(hooks) { }

    public async Task GoToSwagLabs()
    {
        await Page.Result.GotoAsync(Url);
        await Page.Result.WaitForURLAsync(Url, new PageWaitForURLOptions() { WaitUntil = WaitUntilState.DOMContentLoaded});
        
        await Assertions.Expect(UserNameInputSelector).ToBeVisibleAsync();
        await Assertions.Expect(PasswordInputSelector).ToBeVisibleAsync();
        await Assertions.Expect(LoginButtonSelector).ToBeVisibleAsync();
    }

    public async Task EnterUserName(string email)
    {
        await UserNameInputSelector.FillAsync(email);
    }
    
    public async Task EnterPassword(string password)
    {
        await PasswordInputSelector.FillAsync(password);
    }

    public async Task ClickLogin()
    {
        await LoginButtonSelector.ClickAsync();
    }

    public async Task AssertLandingPage()
    {
        await Assertions.Expect(Page.Result).ToHaveURLAsync(TestExecutionHooks.Configs.LandingPage);
        await Assertions.Expect(ProductsPageTitleSelector).ToBeVisibleAsync();
    }
}