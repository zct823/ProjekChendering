// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SchoolApps.IOS
{
	[Register ("ForgotPasswordViewControlelr")]
	partial class ForgotPasswordViewControlelr
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imgLogoView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scvForgotPass { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtViewConfirmPass { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtViewEmail { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtViewPass { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (scvForgotPass != null) {
				scvForgotPass.Dispose ();
				scvForgotPass = null;
			}

			if (imgLogoView != null) {
				imgLogoView.Dispose ();
				imgLogoView = null;
			}

			if (txtViewEmail != null) {
				txtViewEmail.Dispose ();
				txtViewEmail = null;
			}

			if (txtViewPass != null) {
				txtViewPass.Dispose ();
				txtViewPass = null;
			}

			if (txtViewConfirmPass != null) {
				txtViewConfirmPass.Dispose ();
				txtViewConfirmPass = null;
			}
		}
	}
}
