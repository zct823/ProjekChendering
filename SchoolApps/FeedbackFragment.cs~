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

namespace SchoolApps
{
	public class FeedbackFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle savedInstanceState)
		{
			var rootView = layoutInflater.Inflate (Resource.Layout.FeedbackLayout, viewGroup, false);

			// Create your fragment here

			Button btnOpenFeedbackForm = (Button) rootView.FindViewById (Resource.Id.btnOpenFeedbackForm);

			btnOpenFeedbackForm.Click += delegate {
				Activity.StartActivity(typeof(FeedbackForm));
			};

			return rootView;
		}
	}
}

