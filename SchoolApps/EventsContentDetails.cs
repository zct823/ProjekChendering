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
using Newtonsoft.Json;
using SchoolApps.GTKCoreLib;

namespace SchoolApps
{
	[Activity (Label = "Events", Theme = "@style/Theme.Schoolapp")]			
	public class EventsContentDetails : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ViewEventsInfoContent);

			TextView tvEventsTitle = FindViewById<TextView> (Resource.Id.tvEventsInfoTitle);
			TextView tvEventsStart = FindViewById<TextView> (Resource.Id.tvEventsInfoStart);
			TextView tvEventsEnd = FindViewById<TextView> (Resource.Id.tvEventsInfoEnd);
			WebView wvContent = FindViewById<WebView> (Resource.Id.wvEventsInfoContent);

			//Console.WriteLine ("EventsJSON: {0}",Intent.GetStringExtra ("EventsDetailsData") ?? "0");

			//eventsInfoIntent.PutExtra ("EventsTitleData",eventsTitleBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsDetailsData",eventsDetailsBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsStartData",eventsStartBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsEndData",eventsEndBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsStatusData",eventsStatusBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsCreatedData",eventsCreatedBundle[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsModifiedData",eventsModifiedBundle[e.Position.ToString()]);

			//string jksl = Intent.GetStringExtra ("EventsTitleData");
			//Console.WriteLine ("Events JKSL: "+jksl);

			tvEventsTitle.Text = Intent.GetStringExtra ("EventsTitleData").ToString();
			tvEventsStart.Text = Intent.GetStringExtra ("EventsStartData").ToString ();
			tvEventsEnd.Text = Intent.GetStringExtra ("EventsEndData").ToString ();
			wvContent.LoadDataWithBaseURL ("", Intent.GetStringExtra ("EventsDetailsData").ToString(), "text/html", "utf-8", "");
			/*
			var genMsgJSON = JsonConvert.DeserializeObject<Webservice.GEIRootObject> (Intent.GetStringExtra ("EventsDetailsData") ?? "0");

			foreach (var deserialized in genMsgJSON.Event) {
				tvEventsTitle.Text = deserialized.title.ToString ();
				tvEventsStart.Text = deserialized.start.ToString ();
				tvEventsEnd.Text = deserialized.end.ToString ();
				wvContent.LoadDataWithBaseURL ("", deserialized.details.ToString(), "text/html", "utf-8", "");
			}
			*/

		}

		public class EventRootObj
		{
			public string id { get; set; }
			public string event_type_id { get; set; }
			public string title { get; set; }
			public string details { get; set; }
			public string start { get; set; }
			public string end { get; set; }
			public bool all_day { get; set; }
			public string status { get; set; }
			public bool active { get; set; }
			public string created { get; set; }
			public string modified { get; set; }
		}
	}
}

