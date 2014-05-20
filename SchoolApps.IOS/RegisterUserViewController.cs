using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace SchoolApps.IOS
{
	public partial class RegisterUserViewController : UIViewController
	{
		public RegisterUserViewController () : base ("RegisterUserViewController", null)
		{
		}

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

			NavigationController.SetNavigationBarHidden (false, true);
			NavigationItem.Title = "Register";
			EdgesForExtendedLayout = UIRectEdge.None;
			//this.View.Frame = new RectangleF (this.View.Frame.X, 110, this.View.Frame.Width, this.View.Frame.Height);
			//this.View.Bounds = new RectangleF (this.View.Bounds.X, 110, this.View.Bounds.Width, this.View.Bounds.Height);
			//scvRegForm.Frame = new RectangleF (scvRegForm.Frame.X, 0, scvRegForm.Frame.Width, scvRegForm.Frame.Height);
			//scvRegForm.Bounds = new RectangleF (scvRegForm.Bounds.X, 0, scvRegForm.Bounds.Width, scvRegForm.Bounds.Height);

			NSNotificationCenter.DefaultCenter.AddObserver ("UIKeyboardDidShowNotification", keyboardShow);
			NSNotificationCenter.DefaultCenter.AddObserver ("UIKeyboardDidHideNotification", keyboardHide);

		}
			
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		void keyboardShow(NSNotification notification)
		{
			SizeF result = UIScreen.MainScreen.Bounds.Size;

			if (result.Height == 480) {

				UIView.Animate (0.5, () => {

					imgLogoView.Frame = new RectangleF (90, -230, 218, 134);

					this.scvRegForm.Frame = new RectangleF (0, -40, 320, 233);

				},null);

			} else {

				UIView.Animate (0.5, () => {

					imgLogoView.Frame = new RectangleF (90, -230, 218, 134);

					this.scvRegForm.Frame = new RectangleF (5, -40, 320, 233);

				},null);

			}
		}

		void keyboardHide(NSNotification notification)
		{

		}
	}
}

