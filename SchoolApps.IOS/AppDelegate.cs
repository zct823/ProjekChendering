using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SchoolApps.IOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		LoginViewController loginVC;
		NSData deviceTokenNSD;
		NSUserDefaults userDefaults;
		UINavigationController navController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Console.WriteLine ("DFL");
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			navController = new UINavigationController ();
			loginVC = new LoginViewController ();
			navController.PushViewController (loginVC,true);
			window.RootViewController = navController;

			// make the window visible
			window.MakeKeyAndVisible ();

			UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound | UIRemoteNotificationType.Alert;
			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);

			//NSUserDefaults.StandardUserDefaults.ValueForKey = 

			userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetString ("UserDefaultTest Passed".ToString(), "userDefaultTest");
			userDefaults.Synchronize ();

			
			return true;
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			this.deviceTokenNSD = deviceToken.Description.ToString ();
			string deviceTokenNSDStr = this.deviceTokenNSD.ToString ().Replace ("<", "");
			deviceTokenNSDStr = deviceTokenNSDStr.Replace (">", "");
			deviceTokenNSDStr = deviceTokenNSDStr.Replace (" ", "");

			userDefaults.SetString (deviceTokenNSDStr, "deviceToken");
			userDefaults.Synchronize ();
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application, NSError error)
		{
			Console.WriteLine ("Error retrieving Device Token: {0}", error.LocalizedDescription.ToString ());
		}

	}
}

