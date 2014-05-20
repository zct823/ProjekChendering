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
	[Activity (Label = "Sign Up",Theme = "@style/Theme.HoloLight.RemovedTitle")]
	public class LoginUserRegistration : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.LoginRegLayout);

			EditText etNRIC = FindViewById<EditText> (Resource.Id.etUserRegICNo);
			EditText etEmail = FindViewById<EditText> (Resource.Id.etUserRegEmail);
			EditText etpass = FindViewById<EditText> (Resource.Id.etUserRegPassword);
			EditText etconfirmpass = FindViewById<EditText> (Resource.Id.etUserRegConfirmPass);
			Button btnSubmitReg = FindViewById<Button> (Resource.Id.btnUserRegRegister); //w6043x

			btnSubmitReg.Click += delegate {

				Console.WriteLine("Checking Reg Submission...");

				bool pass = false;

				if (etNRIC.Text == "" || etNRIC.Text == null) { pass = false; Toast.MakeText(this,"Your identity card number is required.",ToastLength.Short).Show(); etNRIC.RequestFocus(); }
				else if (etEmail.Text == "" || etEmail.Text == null) { pass = false; Toast.MakeText(this,"Your Email is required.",ToastLength.Short).Show(); etEmail.RequestFocus(); }
				else if (etpass.Text == "" || etpass.Text == null) { pass = false; Toast.MakeText(this,"Your Password is required.",ToastLength.Short).Show(); etpass.RequestFocus(); }
				else if (etconfirmpass.Text == "" || etconfirmpass.Text == null) { pass = false; Toast.MakeText(this,"Confirmation password is required.",ToastLength.Short).Show(); etconfirmpass.RequestFocus(); }
				else if (etpass.Text != etconfirmpass.Text) { pass = false; Toast.MakeText(this,"Password mismatched. Consider check and try again.", ToastLength.Short).Show(); etpass.RequestFocus(); }
				else { pass = true; } 

				if (pass == true)
				{
					registerTheUser(etNRIC.Text.ToString(),etEmail.Text.ToString(),etpass.Text.ToString(), "1");
				}

			};

		}

		public void registerTheUser(string NRIC, string eMail, string etPass, string schoolID)
		{
			string regStatus = "";
			string regMsg = "";

			Webservice wbc = new Webservice();

			var loginUserJSON = JsonConvert.DeserializeObject<Webservice.GRMRootObject> (wbc.getRegistrationMsg(NRIC.ToString(),eMail.ToString(),etPass.ToString(),schoolID.ToString()));

			foreach (var deserialized in loginUserJSON.msg) {
			
				regStatus = deserialized.success.ToString ();
				regMsg = deserialized.message.ToString ();

			}

			if (regStatus == "0") {
				Toast.MakeText (this, regMsg.ToString (), ToastLength.Long).Show();
			} else {
				Toast.MakeText (this, "Registration Success", ToastLength.Long).Show();
			}
		}
	}
}

