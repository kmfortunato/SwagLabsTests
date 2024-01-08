using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public abstract class BasePage
{
    protected string? Url { get; }
    protected Task<IPage> Page { get; }
    
    protected BasePage(TestExecutionHooks hooks)
    {
        Url = TestExecutionHooks.Configs.Url;
        Page = hooks.Page;
    }
}