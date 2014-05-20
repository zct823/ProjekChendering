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
	public class EventsAdapter : BaseAdapter<EventsItem>
	{
		List<EventsItem> eventsItem;
		Activity context;
		public EventsAdapter(Activity context, List<EventsItem> eventsItem)
		{
			this.eventsItem = eventsItem;
			this.context = context;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override EventsItem this[int position]
		{
			get { return eventsItem[position]; }
		}
		public override int Count
		{
			get { return eventsItem.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = eventsItem[position];

			View view = convertView;
			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.EventsListView, null);
			view.FindViewById<TextView>(Resource.Id.tvEventsTitle).Text = item.EventsTitle;
			view.FindViewById<TextView>(Resource.Id.tvEventsDate).Text = item.EventsDateTime;
			view.FindViewById<ImageView>(Resource.Id.ivEventsIcon).SetImageResource(item.IconImageID);

			return view;
		}
	}
}

