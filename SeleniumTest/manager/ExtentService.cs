using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using SharpCompress;


namespace SeleniumTest.manager
{
    public class ExtentService
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentService()
        {
            var reporter = new ExtentHtmlReporter(@"C:\Users\RAS_T\source\repos\BladeDark\SeleniumTestCSharp\TestResults\index.html");
            reporter.Config.Theme = Theme.Dark;
            Instance.AttachReporter(reporter);
        }

        private ExtentService()
        {
        }
    }
}
