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
using Android.Webkit;

namespace SchoolApps
{
	[Activity (Label = "School Info", Theme = "@style/Theme.Schoolapp")]			
	public class SchoolInfoActivity : Activity
	{
		WebView schoolInfoWebView;
		string schoolAppsURL = "http://1mtris.ingeniworks.com.my/schoolapps/";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.SchoolInfoLayout);
			schoolInfoWebView = (WebView)FindViewById (Resource.Id.wvSchoolInfoLayout);
			schoolInfoWebView.Settings.JavaScriptEnabled = true;
			schoolInfoWebView.LoadUrl (schoolAppsURL+"schools/view/1");
		}
	}
}

