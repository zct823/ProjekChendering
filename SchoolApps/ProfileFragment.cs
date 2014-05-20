using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace SchoolApps
{
	public class ProfileFragment : Fragment
	{
		WebView profileLayoutWebview;
		string schoolAppsURL = "http://1mtris.ingeniworks.com.my/schoolapps/users/profile/";
		protected static ProgressDialog theProgressDialog;

		public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle savedInstanceState)
		{
		
			var rootView = layoutInflater.Inflate (Resource.Layout.ProfileLayout, viewGroup, false);
			ISharedPreferences preferences = Application.Context.GetSharedPreferences ("SchoolApps", FileCreationMode.Private);
			//ISharedPreferencesEditor prefedit = preferences.Edit ();
			Toast.MakeText (Activity, preferences.GetString("username",null), ToastLength.Long).Show ();

			profileLayoutWebview = (WebView)rootView.FindViewById (Resource.Id.wvProfileLayout);
			profileLayoutWebview.Settings.JavaScriptEnabled = true;
			profileLayoutWebview.LoadUrl (schoolAppsURL+preferences.GetString("username",null)+"/1");

			//theProgressDialog = ProgressDialog.Show (Activity, "Loading Content", "Please wait...",false);

			return rootView;
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

