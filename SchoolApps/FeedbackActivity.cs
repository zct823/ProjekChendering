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

namespace SchoolApps
{
	[Activity (Label = "Feedback", Theme = "@style/Theme.Schoolapp")]			
	public class FeedbackActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			SetContentView (Resource.Layout.FeedbackLayout);

			Button btnOpenFeedbackForm = (Button) FindViewById (Resource.Id.btnOpenFeedbackForm);

			btnOpenFeedbackForm.Click += delegate {

				StartActivity(typeof(FeedbackForm));

			};
		}
	}
}

