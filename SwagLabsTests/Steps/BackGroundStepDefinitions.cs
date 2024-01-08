using SwagLabsTests.Hooks;
using SwagLabsTests.PageObjects;

namespace SwagLabsTests.Steps;

[Binding]
public sealed class BackGroundStepDefinitions
{
    private readonly LoginPage _loginPage;
    
    public BackGroundStepDefinitions(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }
    
    [Given(@"I'm at Swag Labs login page")]
    public async Task GivenImAtSwagLabsLoginPage()
    {
        await _loginPage.GoToSwagLabs();
    }
    
    [Given(@"I fill in the login fields")]
    public async Task GivenIFillInTheLoginFields()
    {
        await _loginPage.EnterUserName(TestExecutionHooks.Configs.Username);
        await _loginPage.EnterPassword(TestExecutionHooks.Configs.Password);
    }

    [Given(@"I click the login button")]
    public async Task GivenIClickTheLoginButton()
    {
        await _loginPage.ClickLogin();
    }

    [Given(@"I'm at Swag Labs landing page")]
    public async Task GivenImAtSwagLabsLandingPage()
    {
        await _loginPage.AssertLandingPage();
    }
}