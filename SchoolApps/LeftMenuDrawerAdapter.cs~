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
	public class LeftMenuDrawerAdapter : BaseAdapter<LeftMenuDrawerItems>
	{
		List<LeftMenuDrawerItems> leftMenuDrawerItems;
		Activity context;
		public LeftMenuDrawerAdapter(Activity context, List<LeftMenuDrawerItems> leftMenuDrawerItems)
		{
			this.leftMenuDrawerItems = leftMenuDrawerItems;
			this.context = context;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override LeftMenuDrawerItems this[int position]
		{
			get { return leftMenuDrawerItems[position]; }
		}
		public override int Count
		{
			get { return leftMenuDrawerItems.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = leftMenuDrawerItems[position];

			View view = convertView;
			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.LeftMenuListViewCell, null);
			view.FindViewById<TextView>(Resource.Id.tvLeftMenuListViewLabel).Text = item.LeftMenuDrawerLabel;
			view.FindViewById<ImageView>(Resource.Id.ivLeftMenuListViewIconImg).SetImageResource(item.LeftMenuDrawerIconID);

			return view;
		}
	}
}

