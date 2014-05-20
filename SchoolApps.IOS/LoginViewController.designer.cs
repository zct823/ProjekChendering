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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLoginForgotPass { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoginRegister { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoginSubmit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imgLoginLogo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblLoginNotify { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scvLoginForm { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtLoginEmail { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtLoginPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLoginRegister != null) {
				btnLoginRegister.Dispose ();
				btnLoginRegister = null;
			}

			if (btnLoginForgotPass != null) {
				btnLoginForgotPass.Dispose ();
				btnLoginForgotPass = null;
			}

			if (btnLoginSubmit != null) {
				btnLoginSubmit.Dispose ();
				btnLoginSubmit = null;
			}

			if (imgLoginLogo != null) {
				imgLoginLogo.Dispose ();
				imgLoginLogo = null;
			}

			if (lblLoginNotify != null) {
				lblLoginNotify.Dispose ();
				lblLoginNotify = null;
			}

			if (scvLoginForm != null) {
				scvLoginForm.Dispose ();
				scvLoginForm = null;
			}

			if (txtLoginEmail != null) {
				txtLoginEmail.Dispose ();
				txtLoginEmail = null;
			}

			if (txtLoginPassword != null) {
				txtLoginPassword.Dispose ();
				txtLoginPassword = null;
			}
		}
	}
}
