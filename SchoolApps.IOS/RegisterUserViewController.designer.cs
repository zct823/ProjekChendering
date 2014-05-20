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
	[Register ("RegisterUserViewController")]
	partial class RegisterUserViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imgLogoView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scvRegForm { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtRegConfirmPass { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtRegEmail { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtRegNRIC { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtRegPass { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgLogoView != null) {
				imgLogoView.Dispose ();
				imgLogoView = null;
			}

			if (scvRegForm != null) {
				scvRegForm.Dispose ();
				scvRegForm = null;
			}

			if (txtRegConfirmPass != null) {
				txtRegConfirmPass.Dispose ();
				txtRegConfirmPass = null;
			}

			if (txtRegEmail != null) {
				txtRegEmail.Dispose ();
				txtRegEmail = null;
			}

			if (txtRegNRIC != null) {
				txtRegNRIC.Dispose ();
				txtRegNRIC = null;
			}

			if (txtRegPass != null) {
				txtRegPass.Dispose ();
				txtRegPass = null;
			}
		}
	}
}
