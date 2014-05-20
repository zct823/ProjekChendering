using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Android.Util;
using Gcm.Client;
using System.Text;
using System.Threading;
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps
{
	[Activity (Label = "SchoolApps",Theme = "@style/Theme.HoloLight.RemovedTitle")]
	[BroadcastReceiver(Permission = "com.google.android.c2dm.permission.SEND")]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RETRY" })]

	public class MainActivity : Activity
	{
		ProgressDialog theProgress;
		EditText etLogin;
		EditText etPassword;
		public const string projID =  "763292171660";
		const string TAG = "zul.mzmz@gmail.com";
		string registerationID = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);
			//getAndroidDeviceToken ();

			Button btnLogin = FindViewById<Button> (Resource.Id.btnLogin);
			etLogin = FindViewById<EditText> (Resource.Id.etLoginEmail);
			etPassword = FindViewById<EditText> (Resource.Id.etLoginPass);
			TextView tvRegisterBind = FindViewById<TextView> (Resource.Id.tvRegister);
			TextView tvResetPassBind = FindViewById<TextView> (Resource.Id.tvForgotPass);

			etLogin.EditorAction += HandleEditorAction;
			etPassword.EditorAction += HandleSubmit;

			etLogin.Text = "xsrol@yahoo.com";
			etPassword.Text = "1234";

			btnLogin.Click += delegate {

				InputMethodManager imman = (InputMethodManager)GetSystemService(Context.InputMethodService);
				imman.HideSoftInputFromWindow(etLogin.WindowToken, 0);
				imman.HideSoftInputFromWindow(etPassword.WindowToken, 0);

				theProgress = ProgressDialog.Show(this,"SchoolApps Login", "Logging In. Please wait...", true);

				// Run new thread for initating login, since the ProgressDialog should appear first.

				runTheThread();
			};

			tvRegisterBind.Click += delegate {

				StartActivity(typeof(LoginUserRegistration));

			};

			tvResetPassBind.Click += delegate {

				StartActivity(typeof(LoginResetPass));

			};

		}

		private void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
		{
			e.Handled = false;
			if (e.ActionId == ImeAction.Send)
			{
				etPassword.RequestFocus ();
				e.Handled = true;   
			}
		}

		private void HandleSubmit(object sender, TextView.EditorActionEventArgs e)
		{
			e.Handled = false;
			if (e.ActionId == ImeAction.Send)
			{
				runTheThread ();
				e.Handled = true;   
			}
		}

		private void runTheThread ()
		{
			//Java.Lang.Thread vThread = new Java.Lang.Thread(delegate
			//	{
					initLogin();
			//	});

			//vThread.Start();
		}

		private void initLogin()
		{
			registerationID = GcmClient.GetRegistrationId (this);

			if (registerationID == null) {
				Java.Lang.Thread.Sleep (5000);
			} else {
				Java.Lang.Thread.Sleep (1000);
			}

			Webservice wbs = new Webservice ();
			var getLoginStatus = wbs.getLoginData (etLogin.Text, etPassword.Text, registerationID);



			Console.WriteLine ("Email is "+etLogin.Text+" and password is "+etPassword.Text+" and regid is "+registerationID);
			Console.WriteLine ("The login status is "+getLoginStatus);

			if (getLoginStatus.Equals ("1")) {
				successObj ();
			} else {
				Toast.MakeText (this, "Sorry. Either your username or your password is not matched. Please try again.", ToastLength.Long).Show();
				theProgress.Hide ();
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

		private void setMessagesToDatabase()
		{
			ISharedPreferences preferences = GetSharedPreferences ("SchoolApps",FileCreationMode.Private);
			DatabaseAccess dbAccess = new DatabaseAccess();
			Webservice wbsGenInfoData = new Webservice();
			preferences = Application.Context.GetSharedPreferences ("SchoolApps", FileCreationMode.Private);

			dbAccess.SettingUpDataAccessForMsg();

			try
			{
				for (int i = 0; i <= 999999; i++)
				{
					var wbsGenInfoDataJSON = JsonConvert.DeserializeObject<Webservice.GMVNRootObject> (wbsGenInfoData.getMessagesViaNetwork(i.ToString(),preferences.GetString("username",null)));

					foreach (var deserialized in wbsGenInfoDataJSON.data) {

						string readed;

						if (deserialized.mread == false)
						{
							readed = "0";
						}
						else
						{
							readed = "1";
						}

						dbAccess.storeTheMessageOnDatabase (deserialized.id.ToString(), deserialized.title.ToString(), deserialized.content.ToString(), deserialized.sendtime.ToString(), deserialized.Sender.name.ToString(), readed);

						Console.WriteLine("Outputted raw from webservice: ID: "+deserialized.id+" TITLE: "+deserialized.title+" Content: "+deserialized.content+" Sendtime: "+deserialized.sendtime+" Sender: "+deserialized.Sender.name.ToString()+" Readed: "+readed);

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Message ended with expected exception: "+e);
			}

		}

		private void successObj()
		{
			ISharedPreferences preferences = GetSharedPreferences ("SchoolApps",FileCreationMode.Private);
			ISharedPreferencesEditor prefedit = preferences.Edit ();
			prefedit.PutString ("username", etLogin.Text);
			prefedit.PutString ("gcmTokenId", registerationID);
			prefedit.Apply ();

			//StartActivity (typeof(EntranceToMain));
			//theProgress.Hide ();
			/*
			Thread vThread = new Thread(new ThreadStart(delegate
				{
					RunOnUiThread(() => setMessagesToDatabase());

				}));

			vThread.Start();
*/
			StartActivity (typeof(EntranceToMain));

			this.Finish ();
		}
			
	}
		
}


