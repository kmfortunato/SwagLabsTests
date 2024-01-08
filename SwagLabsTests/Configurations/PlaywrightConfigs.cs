namespace SwagLabsTests.Configurations;

public class PlaywrightConfigs
{
    public string? Url { get; set; }
    public string? LandingPage { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? AttachmentTemplate { get; set; } = Environment.GetEnvironmentVariable("ATTACHMENT_TEMPLATE");
    public string OutputDir { get; set; } = "testoutput/";
    public string? RecordVideoDir { get; set; }
    public string? ScreenshotDir { get; set; }
    public string? TraceDir { get; set; }
    public bool RecordFailedOnly { get; set; }
    public bool ScreenshotFailedOnly { get; set; }
    public bool TraceFailedOnly { get; set; }  
}