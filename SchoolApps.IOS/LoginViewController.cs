using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SchoolApps.GTKCoreLib;

namespace SchoolApps.IOS
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController () : base ("LoginViewController", null)
		{
		}

		bool keyboardIsShown = false;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			NavigationController.SetNavigationBarHidden (true, false);

			btnLoginSubmit.TouchUpInside += (object sender, EventArgs e) => {

				this.View.EndEditing(true);

				//MyClass myc = new MyClass ();

				//var getStatus = myc.getLoginData("xsrol@yahoo.com","12345","");

				string getUserDefTest = NSUserDefaults.StandardUserDefaults.StringForKey("userDefaultTest");
				string getDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("deviceToken");

				Console.WriteLine("User Default Test Result: {0}",getUserDefTest);
				Console.WriteLine("Device token is {0}",getDeviceToken);

				Webservice wbc = new Webservice ();

				var getStatus = wbc.getLoginData(txtLoginEmail.Text.ToString(),txtLoginPassword.Text.ToString(),getDeviceToken);

				Console.WriteLine("Your getstatus is {0}",getStatus);

			};

			btnLoginRegister.TouchUpInside += (object sender, EventArgs e) => {
			
				RegisterUserViewController ruvc = new RegisterUserViewController();
				NavigationController.PushViewController(ruvc,true);

			};

			btnLoginForgotPass.TouchUpInside += (object sender, EventArgs e) => {

				ForgotPasswordViewControlelr fpvc = new ForgotPasswordViewControlelr ();
				NavigationController.PushViewController(fpvc,true);
			};

			NSNotificationCenter.DefaultCenter.AddObserver ("UIKeyboardDidShowNotification", keyboardShow);
			NSNotificationCenter.DefaultCenter.AddObserver ("UIKeyboardDidHideNotification", keyboardHide);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationController.SetNavigationBarHidden (true, true);
		}

		void keyboardShow(NSNotification notification)
		{
			if (keyboardIsShown)
				return;

			Console.WriteLine ("Keyboard Up");

			SizeF result = UIScreen.MainScreen.Bounds.Size;

			if (result.Height == 480) {

				UIView.Animate (0.5, () => {

					imgLoginLogo.Frame = new RectangleF (90, -230, 218, 134);

					this.scvLoginForm.Frame = new RectangleF (0, 50, 320, 233);

				},null);

			} else {

				UIView.Animate (0.5, () => {

					imgLoginLogo.Frame = new RectangleF (90, -230, 218, 134);

					this.scvLoginForm.Frame = new RectangleF (5, 250, 320, 233);

				},null);
			}

			keyboardIsShown = true;
		}

		void keyboardHide(NSNotification notification)
		{
			Console.WriteLine ("Keyboard Down");

			SizeF result = UIScreen.MainScreen.Bounds.Size;

			if (result.Height == 480) {

				UIView.Animate (0.5, () => {

					imgLoginLogo.Frame = new RectangleF (50, 50, 218, 134);

					this.scvLoginForm.Frame = new RectangleF (0, 200, 320, 233);

				},null);

			} else {

				UIView.Animate (0.5, () => {

					imgLoginLogo.Frame = new RectangleF (50, 50, 218, 134);

					this.scvLoginForm.Frame = new RectangleF (5, 250, 320, 233);

				},null);
			}

			keyboardIsShown = false;
		}

	}
}

