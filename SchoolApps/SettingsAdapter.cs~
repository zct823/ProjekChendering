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
	public class SettingsAdapter : BaseAdapter<SettingsItem>
	{
		List<SettingsItem> settingsItem;
		Activity context;

		public SettingsAdapter(Activity context, List<SettingsItem> settingsItem) : base()
		{
			this.context = context;
			this.settingsItem = settingsItem;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override SettingsItem this[int position]
		{
			get { return settingsItem[position]; }
		}
		public override int Count
		{
			get { return settingsItem.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = settingsItem[position];

			View view = convertView;
			if (view == null) { // no view to re-use, create new
				view = context.LayoutInflater.Inflate (Resource.Layout.SettingsListingView, null);
				view.FindViewById<TextView> (Resource.Id.tvSettingsName).Text = item.SettingsName;
				view.FindViewById<ImageView> (Resource.Id.ivSettingsIcon).SetImageResource (item.SettingsIconID);
			}

			return view;
		}
	}
}

