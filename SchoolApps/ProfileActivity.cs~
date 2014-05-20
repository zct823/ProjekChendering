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
using Android.Webkit;

namespace SchoolApps
{

	[Activity (Label = "Profile", Theme = "@style/Theme.Schoolapp")]			
	public class ProfileActivity : Activity
	{
		WebView profileLayoutWebview;
		string schoolAppsURL = "http://1mtris.ingeniworks.com.my/schoolapps/users/profile/";
		protected static ProgressDialog theProgressDialog;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ProfileLayout);
			// Create your application here
			ISharedPreferences preferences = Application.Context.GetSharedPreferences ("SchoolApps", FileCreationMode.Private);
			//ISharedPreferencesEditor prefedit = preferences.Edit ();
			//Toast.MakeText (this, preferences.GetString("username",null), ToastLength.Long).Show ();

			profileLayoutWebview = (WebView)FindViewById (Resource.Id.wvProfileLayout);
			profileLayoutWebview.Settings.JavaScriptEnabled = true;
			profileLayoutWebview.LoadUrl (schoolAppsURL+preferences.GetString("username",null)+"/1");

		}

		private class profileLayoutWebviewClient : WebViewClient
		{

			public override void OnPageStarted (WebView view, string url, Android.Graphics.Bitmap favicon)
			{
				base.OnPageStarted (view, url, favicon);

			}

			public override void OnPageFinished (WebView view, string url)
			{
				base.OnPageFinished (view, url);
				//theProgressDialog.Hide ();
			}
		}
	}
}

