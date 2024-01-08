using Microsoft.Playwright;
using SwagLabsTests.Configurations;
using Microsoft.Extensions.Configuration;
using SpecFlow.Actions.Playwright;

namespace SwagLabsTests.Hooks;

[Binding]
public class TestExecutionHooks
{
    public static PlaywrightConfigs Configs = new();
    private readonly ScenarioContext _scenario;
    private readonly BrowserDriver _driver;
    public Task<IPage> Page { get; private set; } = null!;
    private IBrowserContext? BrowserContext { get; set; }
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        
    public TestExecutionHooks(ScenarioContext scenario, BrowserDriver driver, ISpecFlowOutputHelper specFlowOutputHelper)
    {
        _scenario = scenario;
        _driver = driver;       
        _specFlowOutputHelper = specFlowOutputHelper;
    } 

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // To read the configs set on appsettings.json file
        var configurationRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        Configs = configurationRoot.GetSection(nameof(PlaywrightConfigs))
            .Get<PlaywrightConfigs>() ?? Configs;
    }
        
    [BeforeScenario]
    public async Task BeforeScenario()
    {
        BrowserContext = await _driver.Current.Result.NewContextAsync(new()
        {
            RecordVideoDir = Configs.RecordVideoDir != null ? Path.Combine(Configs.OutputDir, Configs.RecordVideoDir) : null,
            ViewportSize = ViewportSize.NoViewport, // To not set a default screen-size
                
        });

        if (Configs.TraceDir != null)
        {
            await BrowserContext.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true
                    
            });
        }
        // Ensures the login page is open before each scenario
        Page = BrowserContext.NewPageAsync();
        Page.Result.Load += OnPageLoad;
    }
        
    private void OnPageLoad(object? _, IPage b)
    {
        _specFlowOutputHelper.WriteLine("Called OnPageLoad");
    }   
        
    [AfterStep]
    public async Task AfterStep()
    {
        // To take screenshots on failed scenarios
        try
        {
            if (Configs.ScreenshotDir != null)
            {
                if (_scenario.TestError == null && Configs.ScreenshotFailedOnly) return;

                var status = _scenario.TestError == null ? "succeeded" : "FAILED";
                var scenarioTitle = _scenario.ScenarioInfo.Title.Replace(" ", "_");
                var stepInfo = _scenario.StepContext.StepInfo;
                var step = $"{stepInfo.StepDefinitionType} {stepInfo.Text}".Replace(" ", "_");
                var filename = $"{scenarioTitle}_{step}_{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.{status}.png";
                var filepath = Path.Combine(Configs.ScreenshotDir, filename);
                await Page.Result.ScreenshotAsync(new PageScreenshotOptions { Path = Path.Combine(Configs.OutputDir, filepath) });
                if (Configs.AttachmentTemplate != null)
                {
                    _specFlowOutputHelper.AddAttachment(string.Format(Configs.AttachmentTemplate, filepath));
                }
            }
        }
        catch (Exception e)
        {
            _specFlowOutputHelper.WriteLine(e.Message);
        }
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        Page.Result.Load -= OnPageLoad;

        if (BrowserContext == null) return;

        string status = _scenario.TestError == null ? "succeeded" : "FAILED";
        if (Configs.TraceDir != null)
        {
            var scenarioTitle = _scenario.ScenarioInfo.Title.Replace(" ", "_");
            var traceFilename = $"{scenarioTitle}.{status}.traces.zip";
            var traceFilepath = Path.Combine(Configs.TraceDir, traceFilename);
            await BrowserContext.Tracing.StopAsync(new()
            {
                Path = Path.Combine(Configs.OutputDir, traceFilepath)
            });
            if (_scenario.TestError == null && Configs.TraceFailedOnly)
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, Configs.OutputDir, traceFilepath));
            }
            else if (Configs.AttachmentTemplate != null)
            {
                _specFlowOutputHelper.AddAttachment(string.Format(Configs.AttachmentTemplate, traceFilepath));
            }
        }

        await BrowserContext.CloseAsync();

        // Rename scenario video with scenario Title 
        if (Page.Result.Video != null)
        {
            string path = await Page.Result.Video.PathAsync();
            if (_scenario.TestError == null && Configs.RecordFailedOnly)
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, path));
            }
            else
            {
                var scenarioTitle = _scenario.ScenarioInfo.Title.Replace(" ", "_");
                var filepath = Path.Combine(Configs.RecordVideoDir!, $"{scenarioTitle}.{status}.webm");
                string scenarioVideoPath = Path.Combine(Environment.CurrentDirectory, Configs.OutputDir, filepath);
                File.Move(Path.Combine(Environment.CurrentDirectory, path), scenarioVideoPath, true);
                if (Configs.AttachmentTemplate != null)
                {
                    _specFlowOutputHelper.AddAttachment(string.Format(Configs.AttachmentTemplate, filepath));
                }
                _specFlowOutputHelper.WriteLine($"Recorded scenario video at {scenarioVideoPath}");
            }
        }
    }
}