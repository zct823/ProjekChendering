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
	[Activity (Label = "Message Details", Theme = "@style/Theme.Schoolapp")]			
	public class PrivMsgContentDetails : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ViewPrivateMsgContent);

			TextView tvFrom = FindViewById<TextView> (Resource.Id.tvPrivMsgFrom);
			TextView tvTitle = FindViewById<TextView> (Resource.Id.tvPrivMsgTitle);
			TextView tvCreated = FindViewById<TextView> (Resource.Id.tvPrivMsgCreatedOn);
			WebView wvContent = FindViewById<WebView> (Resource.Id.wvPrivMsgContent);

			string genMsgID = Intent.GetStringExtra ("MessageID") ?? "0";

			DatabaseAccess da = new DatabaseAccess ();
			var genMsgJSON = JsonConvert.DeserializeObject<DatabaseAccess.RDBMCRootObject> (da.retrieveDBMessageContent (genMsgID));

			//var dbMsgContentDeserialized = JsonConvert.DeserializeObject ();
			foreach (var deserialized in genMsgJSON.items) {

				tvFrom.Text = deserialized.msg_sender.ToString();
				tvTitle.Text = deserialized.msg_title.ToString();
				tvCreated.Text = deserialized.msg_sendtime.ToString();
				wvContent.LoadDataWithBaseURL ("", deserialized.msg_content.ToString(), "text/html", "utf-8", "");

			}



		}
	}
}

