# SwagLabsTests

SwagLabsTests is a web test automation project developed with Playwright with SpecFlow and Page Objects Model (POM) in .NET (C#) to test the shopping cart features on [Swag Labs webpage](https://www.saucedemo.com/).


## Run the project locally

1. Clone the project
```
git clone git@github.com:kmfortunato/SwagLabsTests.git
```

2. Install NuGet packages
```
nuget restore
```
3. Run the tests

Use the <code>.feature</code> files to run the tests for better visualization.

## Usage Instructions

### Login info
At the `appsettings.json file` there are the URL, username and password info.

### Test execution options
At the `specflow.actions.json` file there are some options for config the tests executions:

- `browser` is set to Chrome, but there are other available options, such as Firefox and Chromium.
- `--start-maximized` argument to maximize the browser window to the current screen size _(note that this argument is different for each chosen browser)_. 
- `headless` set true to not to see the tests executions (the browser tabs won't open).