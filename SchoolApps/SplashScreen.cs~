using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gcm.Client;

namespace SchoolApps
{
	[Activity (Theme = "@style/Theme.SplashScreen", MainLauncher = true, NoHistory = true)]			
	public class SplashScreen : Activity
	{
		ProgressDialog theProgression;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			getAndroidDeviceToken ();
			//waitingToken ();

			Thread.Sleep (10000);
			StartActivity (typeof(MainActivity));

			this.Finish ();

		}

		private void waitingToken()
		{
			theProgression = ProgressDialog.Show(this, "Login", "Please wait...", true);
			var registerationID = GcmClient.GetRegistrationId (this);

			if (string.IsNullOrEmpty (registerationID)) {
				Console.WriteLine ("Waiting Token...");
				Thread.Sleep (20000);
				waitingToken ();
			} else {
				StartActivity (typeof(MainActivity));
				this.Finish ();
			}

		}

		private void getAndroidDeviceToken()
		{
			GcmClient.CheckDevice (this);
			GcmClient.CheckManifest (this);
			var registerationID = GcmClient.GetRegistrationId (this);

			if (string.IsNullOrEmpty (registerationID)) {

				//GcmClient.Register (this,);
				GcmClient.Register (this, GcmBroadcastReceiver.SENDER_IDS);

			} else {
				Console.WriteLine ("Already registered with id is "+GcmClient.GetRegistrationId (this));
			}

			//return "Value";
		}
	}
}

