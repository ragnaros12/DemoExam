using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;

namespace TesWpfApp2
{
	public class Tests
	{
		Application app;
		[SetUp]
		public void Setup()
		{
			app = Application.Launch("./WpfApp2.exe");
		}

		[Test]
		public void Test1()
		{
			UIA3Automation automation = new UIA3Automation();
			Window window = app.GetMainWindow(automation);
			window.FindFirstDescendant(cf => cf.ByAutomationId("LoginText")).AsTextBox().Text = "11";
			window.FindFirstDescendant(cf => cf.ByAutomationId("Password")).AsTextBox().Text = "1";
			window.FindFirstDescendant(cf => cf.ByAutomationId("login")).AsButton().Click();

			var w = automation.GetDesktop();
			var app1 = w.FindFirstDescendant(cf => cf.ByName("LoginResult"));
			Assert.NotNull(app1.FindFirstDescendant(cf => cf.ByText("Вход успешен. Добрый день 11")));
		}
	}
}