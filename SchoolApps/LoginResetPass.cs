using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps
{
	[Activity (Label = "Forgot Password",Theme = "@style/Theme.HoloLight.RemovedTitle")]
	public class LoginResetPass : Activity
	{
		ProgressDialog pdResetPass;
		Java.Lang.Thread requestPassOnThread;
		Handler requestPassOnThreadHandler;
		Java.Lang.IRunnable requestPassRunnable;

		EditText etForgotPassEmail;
		EditText etForgotPassNewPass;
		EditText etForgotPassConfirmPass;
		Button btnForgotPassSubmit;

		string forgotPassStatus = "";
		string forgotPassMsg = "";

		/*
		class Runnable : Java.Lang.Object, Java.Lang.IRunnable
		{
			Action action;
			public Runnable (Action action)
			{
				this.action = action;
			}
			public void Run ()
			{
				action ();
			}
		}

		class Handler : Android.OS.Handler
		{
			Action action;
			public Handler (Action action)
			{
				this.action = action;
			}
			public void Run ()
			{
				action ();
			}
		}
			
*/
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.LoginResetPass);

			etForgotPassEmail = FindViewById<EditText> (Resource.Id.etResetPassEmail);
			etForgotPassNewPass = FindViewById<EditText> (Resource.Id.etResetPassNewPass);
			etForgotPassConfirmPass = FindViewById<EditText> (Resource.Id.etResetPassConfirmPass);
			btnForgotPassSubmit = FindViewById<Button> (Resource.Id.btnResetPassSubmit);

			pdResetPass = new ProgressDialog (this);
			pdResetPass.SetMessage ("Please wait...");
			pdResetPass.SetProgressStyle (ProgressDialogStyle.Spinner);


			btnForgotPassSubmit.Click += delegate {

				Console.WriteLine("Checking Forgot Pass Submission...");

				bool pass = false;

				if (etForgotPassEmail.Text == "" || etForgotPassEmail.Text == null) { pass = false; Toast.MakeText(this,"Your identity card number is required.",ToastLength.Short).Show(); etForgotPassEmail.RequestFocus(); }
				else if (etForgotPassNewPass.Text == "" || etForgotPassNewPass.Text == null) { pass = false; Toast.MakeText(this,"Your Email is required.",ToastLength.Short).Show(); etForgotPassNewPass.RequestFocus(); }
				else if (etForgotPassConfirmPass.Text == "" || etForgotPassConfirmPass.Text == null) { pass = false; Toast.MakeText(this,"Your Password is required.",ToastLength.Short).Show(); etForgotPassConfirmPass.RequestFocus(); }
				else if (etForgotPassNewPass.Text != etForgotPassConfirmPass.Text) { pass = false; Toast.MakeText(this,"Password mismatched. Consider check and try again.", ToastLength.Short).Show(); etForgotPassNewPass.RequestFocus(); }
				else { pass = true; } 

				if (pass == true)
				{
					pdResetPass.Show();

					requestPassOnThread = new Java.Lang.Thread (async delegate() {

					});
					sendForgotPassForm (etForgotPassEmail.Text.ToString (), etForgotPassNewPass.Text.ToString (), "1");
					//requestPassOnThread.Start();
					//requestPassOnThread.Join();
					//pdResetPass.Hide ();
					//requestPassRunnable = new Java.Lang.IRunnable (RunonRunnable);

					//requestPassOnThreadHandler = new Handler (RunonRunnable);

					requestPassOnThread.Start();

					//requestPassRunnable.Run();
					//requestPassOnThreadHandler.Run();
				}

			};
		}

		public void RunonRunnable()
		{
			Console.WriteLine ("Runnable is entered..");
			sendForgotPassForm (etForgotPassEmail.Text.ToString (), etForgotPassNewPass.Text.ToString (), "1");
			//requestPassOnThreadHandler.SendMessage (0);
		}

		public void RunOnHandlers()
		{
			pdResetPass.Hide ();
			if (forgotPassStatus.ToString () == "0") {
				Toast.MakeText (this, forgotPassMsg.ToString (), ToastLength.Short).Show ();
			} else {
				Toast.MakeText (this, "Password was resetted.", ToastLength.Short).Show ();
			}
		}

		public void sendForgotPassForm(string email, string newPass, string schoolID)
		{
			forgotPassStatus = "";
			forgotPassMsg = "";

			Webservice wbc = new Webservice();

			var loginUserJSON = JsonConvert.DeserializeObject<Webservice.GRMRootObject> (wbc.getResetPassReg(email.ToString(),newPass.ToString(),schoolID.ToString()));

			foreach (var deserialized in loginUserJSON.msg) {

				forgotPassStatus = deserialized.success.ToString ();
				forgotPassMsg = deserialized.message.ToString ();

			}

			RunOnHandlers ();
				
		}
	}
}

