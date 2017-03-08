using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Wayfair
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("continue_as_guest");
			app.Screenshot("Let's start by Tapping on the 'Continue as Guest'");

			app.Tap("search_image");
			app.Screenshot("Then we Tapped on 'Search' Icon");

			Thread.Sleep(8000);
			app.EnterText("Blue Sofa");
			app.Screenshot("Next, we entered our seach, 'Blue Sofa'");

			app.PressEnter();
			app.Screenshot("We Tapped on the 'enter' Button");

			Thread.Sleep(8000);
			app.Tap("basket_product_image");
			app.Screenshot("Then we Tapped on the first Sofa");

			app.Tap("add_to_cart_fab");
			app.Screenshot("We Tapped on the 'Add to Cart' Button");

			Thread.Sleep(8000);
			app.Tap(x => x.Class("android.widget.FrameLayout").Index(6));
			app.Screenshot("We Tapped on the 'Select Upholstery' Button");

			Thread.Sleep(8000);
			app.Tap(x => x.Class("android.widget.FrameLayout").Index(8));
			app.Screenshot("Then we Tapped on the 'Taupe' color");

			Thread.Sleep(8000);
			app.Tap("add_to_cart_fab");
			app.Screenshot("Last, we Tapped on the 'Add to Cart' Button");
		}

	}
}
