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
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps
{
	[Activity (Label = "General Info", Theme = "@style/Theme.Schoolapp")]			
	public class GenMsgContantDetails : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			SetContentView (Resource.Layout.ViewGeneralMsgContent);

			TextView tvFrom = FindViewById<TextView> (Resource.Id.tvGenMsgFrom);
			TextView tvTitle = FindViewById<TextView> (Resource.Id.tvGenMsgTitle);
			TextView tvCreated = FindViewById<TextView> (Resource.Id.tvGenMsgCreatedOn);
			WebView wvContent = FindViewById<WebView> (Resource.Id.wvGenMsgContent);

			string genInfoContentID = Intent.GetStringExtra ("GenInfoID") ?? "0";

			Webservice wbs = new Webservice ();
			var genInfoContentJSON = JsonConvert.DeserializeObject<Webservice.GGICDRootObject> (wbs.getGeneralInfoContentDetails (genInfoContentID));

			tvFrom.Text = "Shahizey Sam";
			tvTitle.Text = "How to train your dragon";
			tvCreated.Text = genInfoContentJSON.created.ToString();

			string gictextformatted = genInfoContentJSON.text.ToString ().Replace("\r\n","<br />");

			wvContent.LoadDataWithBaseURL ("", "<html><body>"+gictextformatted.ToString()+"</body></html>", "text/html", "utf-8", "");


		}
	}
}

