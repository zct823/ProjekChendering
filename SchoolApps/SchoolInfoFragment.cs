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
	public class SchoolInfoFragment : Fragment
	{
		WebView schoolInfoWebView;
		string schoolAppsURL = "http://1mtris.ingeniworks.com.my/schoolapps/";

		public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle savedInstanceState)
		{
			var rootView = layoutInflater.Inflate (Resource.Layout.SchoolInfoLayout, viewGroup, false);
		
			schoolInfoWebView = (WebView)rootView.FindViewById (Resource.Id.wvSchoolInfoLayout);
			schoolInfoWebView.Settings.JavaScriptEnabled = true;
			schoolInfoWebView.LoadUrl (schoolAppsURL+"schools/view/1");

			return rootView;
		}
	}
}

